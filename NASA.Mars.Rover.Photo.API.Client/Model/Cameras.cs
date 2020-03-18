using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Mars.Rover.Photo.API.Client.Model
{
    [JsonObject("cameras")]
    public class Cameras
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
    }
}
