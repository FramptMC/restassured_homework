using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAssured_Homework.Tests.Models
{
    [Serializable]
    public class Book
    {
        [JsonProperty(propertyName: "isbn")]
        public string ISBN { get; set; }

        [JsonProperty(propertyName: "title")]
        public string Title { get; set; }

        [JsonProperty(propertyName: "subTitle")]
        public string SubTitle { get; set; }

        [JsonProperty(propertyName: "author")]
        public string Author { get; set; }

        [JsonProperty(propertyName: "publish_date")]
        public string Publish_date { get; set; }

        [JsonProperty(propertyName: "publisher")]
        public string Publisher { get; set; }

        [JsonProperty(propertyName: "pages")]
        public long Pages { get; set; }

        [JsonProperty(propertyName: "description")]
        public string Description { get; set; }

        [JsonProperty(propertyName: "website")]
        public string WebSite { get; set; }
    }
}
