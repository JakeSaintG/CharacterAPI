using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CharacterAPI.Models
{
    public class Characters
    {
        [JsonProperty(PropertyName = "character")]
        public Character[] Character { get; set; }
    }
}