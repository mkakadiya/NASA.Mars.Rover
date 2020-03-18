using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Mars.Rover.Photo.API.Client.Model
{
    [JsonObject("rover")]
    public class Rover
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("landing_date")]
        public string landing_date { get; set; }
        [JsonProperty("launch_date")]
        public string launch_date { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("max_sol")]
        public int max_sol { get; set; }
        [JsonProperty("max_date")]
        public string max_date { get; set; }
        [JsonProperty("total_photos")]
        public int total_photos { get; set; }
        [JsonProperty("cameras")]
        public List<Cameras> cameras { get; set; }
    }
}
