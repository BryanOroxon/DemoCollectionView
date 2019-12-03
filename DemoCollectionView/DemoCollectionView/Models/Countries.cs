using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoCollectionView.Models
{
    public partial class Countries
    {
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }
        [JsonProperty("Areainkm2")]
        public string Areainkm2 { get; set; }
        [JsonProperty("Population")]
        public string Population { get; set; }        
    }

    public partial class Countries
    {
        public static Countries[] FromJson(string json) => JsonConvert.DeserializeObject<Countries[]>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Countries[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

}
