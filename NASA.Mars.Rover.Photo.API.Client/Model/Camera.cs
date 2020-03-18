using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Mars.Rover.Photo.API.Client.Model
{
    [JsonObject("camera")]
    public class Camera
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("rover_id")]
        public int rover_id { get; set; }
        [JsonProperty("full_name")]
        public string full_name { get; set; }
    }
}
