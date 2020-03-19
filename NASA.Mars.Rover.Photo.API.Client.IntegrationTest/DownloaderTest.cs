using System;
using System.Collections.Generic;
using Xunit;

namespace NASA.Mars.Rover.Photo.API.Client.IntegrationTest
{
    public class DownloaderTest
    {
        [Fact]
        public void Downloader_Returns_PhotoUrls()
        {
            //arrange
            Downloader downloader = new Downloader("https://api.nasa.gov/mars-photos/", @"c:\photos\");
            IEnumerable<string> photoUrls = null;

            //act
            photoUrls = downloader.DownloadPhotoUrlAsync("2019-09-28").Result;

            //assert
            Assert.NotNull(photoUrls);
        }
    }
}
