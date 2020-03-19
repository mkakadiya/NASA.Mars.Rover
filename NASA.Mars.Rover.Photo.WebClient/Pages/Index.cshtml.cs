using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NASA.Mars.Rover.Photo.API.Client;

namespace NASA.Mars.Rover.Photo.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration configuration;

        public IEnumerable<string> PhotoUrls { get; private set; }

        public string Date { get; private set; }

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void OnGet(string date = "2019-09-28")
        {
            IEnumerable<string> photoUrls= null;

            DateTime dateValue;

            //Validate date format then only process with request
            if (DateTime.TryParse(date, out dateValue))
            {
                Downloader downloader = new Downloader(configuration["NasaMarsRoverPhotoEndPoint"], configuration["DirectoryPath"]);

                //Get rover images url
                photoUrls = downloader.DownloadPhotoUrlAsync(dateValue.ToString("yyyy-MM-dd")).Result;

                //Download rover images async. This will done in batch downloading.
                //downloader.DowloadPhotoAsync(photoUrls);

            }
            Date = date.ToString();
            PhotoUrls = photoUrls;
        }
    }
}
