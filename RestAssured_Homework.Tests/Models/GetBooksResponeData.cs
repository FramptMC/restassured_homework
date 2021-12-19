using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAssured_Homework.Tests.Models
{
    [Serializable]
    public class GetBooksResponeData
    {
        [JsonProperty(propertyName: "books")]
        public IEnumerable<Book> Books { get; set; }
    }
}
