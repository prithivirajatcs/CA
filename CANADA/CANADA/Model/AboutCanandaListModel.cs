using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CANADA.Model
{
    public class AboutCanandaListModel
    {
        [JsonProperty("title")]
        public string pagetitle { get; set; }
        [JsonProperty("rows")]
        public List<CAList> calist { get; set; }

        public static implicit operator List<object>(AboutCanandaListModel v)
        {
            throw new NotImplementedException();
        }
    }

    public class CAList
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("imageHref")]
        public string imageHref { get; set; }
    }
}
