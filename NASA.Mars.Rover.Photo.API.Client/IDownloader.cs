using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASA.Mars.Rover.Photo.API.Client
{
    public interface IDownloader
    {
        Task<IEnumerable<string>> DownloadPhotoUrlAsync(string date);

        Task<bool> DowloadPhotoAsync(IEnumerable<string> photoUrls);
    }
}
