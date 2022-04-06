using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CharacterAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CharacterAPI.Services
{
    public static class JSONService
    {
        public static List<Character> ReadFile()
        {
            string fileName = "JSON/characters.json";
            string jsonString = File.ReadAllText(fileName);
            var characterJSON = JsonConvert.DeserializeObject<List<Character>>(jsonString);
            return characterJSON;
        }
    }
}