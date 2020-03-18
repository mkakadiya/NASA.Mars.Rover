using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Mars.Rover.Photo.API.Client.Model
{
    public class Photos
    {
        [JsonProperty("photos")]
        public List<Photo> PhotoList { get; set; }

    }
}
