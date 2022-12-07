using System;
using Newtonsoft.Json;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class Vehicle
    {
        //[JsonProperty(PropertyName = "trackingObjectId")]
        public int trackingObjectId { get; set; }

        /*
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
        */

        public override string ToString()
        {
            //return Id + " " + Latitude + " " + Longitude;
            return trackingObjectId.ToString();
        }
    }
}