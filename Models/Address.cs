using Newtonsoft.Json;

namespace PeopleAPI.Models
{
    public class Address
    {
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "zip")]
        public int Zip { get; set; }
    }
}


 