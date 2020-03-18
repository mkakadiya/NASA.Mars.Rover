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

        public IndexModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void OnGet(string date = "2017-02-27")
        {
            
            Downloader downloader = new Downloader(configuration["NasaMarsRoverPhotoEndPoint"], configuration["DirectoryPath"]);

            //Get rover images url
            IEnumerable<string> photoUrls = downloader.DownloadPhotoUrlAsync(date).Result;

            //Download rover images async
            downloader.DowloadPhotoAsync(photoUrls);

            PhotoUrls = photoUrls;
        }
    }
}
