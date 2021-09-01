using System;
using Newtonsoft.Json;

namespace PeopleAPI.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "birthDate")]
        public DateTime BirthDate { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }

        [JsonProperty(PropertyName = "interests")]
        public string[] Interests { get; set; }
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
    }
}