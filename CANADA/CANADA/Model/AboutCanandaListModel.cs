using System.Collections.Generic;
using Newtonsoft.Json;

namespace CANADA.Model
{
    public class AboutCanandaListModel
    {
        [JsonProperty("title")]
        public string title { get; set; }
        public List<CAList> calist { get; set; }
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
