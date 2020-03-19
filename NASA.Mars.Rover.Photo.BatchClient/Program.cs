using Microsoft.Extensions.Configuration;
using NASA.Mars.Rover.Photo.API.Client;
using System;
using System.Collections.Generic;
using System.IO;

namespace NASA.Mars.Rover.Photo.BatchClient
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {

            //add configuration builder to read settings
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            ProcessBatch();
        }

        public static void ProcessBatch()
        {
            Downloader downloader = new Downloader(configuration["NasaMarsRoverPhotoEndPoint"], configuration["DirectoryPath"]);

            IEnumerable<string> dates = GetDates(configuration["BatchFilename"]);

            foreach (string date in dates)
            {
                //Get rover images url
                IEnumerable<string> photoUrls = downloader.DownloadPhotoUrlAsync(date).Result;

                Console.WriteLine("Downlaoding images...");
                //Download rover images async
                downloader.DowloadPhotoAsync(photoUrls);
            }
        }

        public static IEnumerable<string> GetDates(string filePath)
        {
            List<string> dates = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    var line = sr.ReadLine();
                    DateTime dateValue;
                    while (line != null)
                    {
                        //Try convert file line to date format
                        if (DateTime.TryParse(line, out dateValue))
                        {
                            dates.Add(dateValue.ToString("yyyy-MM-dd"));
                        }
                        else
                        {
                            //Log dates which are not correctly formated
                        }

                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception)
            {
                //log file exception
            }
            

            return dates;
        }
    }
}
