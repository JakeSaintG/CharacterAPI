using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeopleAPI.Models
{
    public class People
    {
        [JsonProperty(PropertyName = "person")]
        public Person[] Person { get; set; }
    }
}