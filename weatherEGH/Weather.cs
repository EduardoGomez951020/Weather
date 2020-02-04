using System;
using Newtonsoft.Json;

namespace weatherEGH
{
    public class Weather
    {
        [JsonProperty("main")]
        public Info Main{ get;set;}

        [JsonProperty("name")]
        public string Name { get; set; }
    }




    public class Info {

        [JsonProperty("temp")]
        public float  Temp { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

     
    }
}
