using NASA.Mars.Rover.Photo.API.Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NASA.Mars.Rover.Photo.API.Client
{
    public class Downloader: IDownloader
    {

        private readonly string _nasaPhotoEndPoint;
        private readonly string _localPhotoPath;

        public Downloader(string endPoint, string localPhotoPath)
        {
            _nasaPhotoEndPoint = endPoint;
            _localPhotoPath = localPhotoPath;
        }
        /// <summary>
        /// This method returns image url of the rover camera images on specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> DownloadPhotoUrlAsync(string date)
        {
            List<string> photoListUrls = new List<string>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_nasaPhotoEndPoint);

            try
            {
                //Call nasa api and extract images url
                HttpResponseMessage responseMessage = await client.GetAsync("api/v1/rovers/curiosity/photos?earth_date=" + date + "&api_key=DEMO_KEY"); //TODO: move url to config
                Photos photos = new Photos();

                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultString = responseMessage.Content.ReadAsStringAsync().Result;
                    photos = JsonConvert.DeserializeObject<Photos>(resultString);

                    foreach (var item in photos.PhotoList)
                        photoListUrls.Add(item.img_src);
                }
            }
            catch (Exception)
            {
                //log exception
            }
            return photoListUrls;
        }

        /// <summary>
        /// This method downloads specified images async
        /// </summary>
        /// <param name="photoUrls"></param>
        /// <returns></returns>
        public async Task<bool> DowloadPhotoAsync(IEnumerable<string> photoUrls)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    foreach (string url in photoUrls)
                    {
                        // Create file path and ensure directory exists
                        var path = Path.Combine(_localPhotoPath, Path.GetFileName(url));
                        Directory.CreateDirectory(_localPhotoPath);

                        // Download the image and write to the file
                        var imageBytes = await httpClient.GetByteArrayAsync(url);
                        await File.WriteAllBytesAsync(path, imageBytes);
                    }
                }
            }
            catch (Exception)
            {
                //log exception
                return false;
            }
            return true;
        }
    }
}
