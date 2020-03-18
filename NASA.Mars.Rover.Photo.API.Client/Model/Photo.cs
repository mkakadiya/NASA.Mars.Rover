using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Mars.Rover.Photo.API.Client.Model
{
    public class Photo
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("sol")]
        public int sol { get; set; }
        [JsonProperty("camera")]
        public Camera camera { get; set; }
        [JsonProperty("img_src")]
        public string img_src { get; set; }
        [JsonProperty("earth_date")]
        public string earth_date { get; set; }
        [JsonProperty("rover")]
        public Rover rover { get; set; }
    }
}
