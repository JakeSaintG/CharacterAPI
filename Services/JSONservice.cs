using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PeopleAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PeopleAPI.Services
{
    public static class JSONService
    {
        public static List<Person> ReadFile()
        {
            string fileName = "JSON/people.json";
            string jsonString = File.ReadAllText(fileName);
            var peopleJSON = JsonConvert.DeserializeObject<List<Person>>(jsonString);
            return peopleJSON;
        }
    }
}