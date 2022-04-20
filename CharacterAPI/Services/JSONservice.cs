using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CharacterAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CharacterAPI.Services
{
    public class JSONService
    {
        static readonly string BaseFile = "JSON/CharactersBaseData.json";
        static readonly string CharacterFile = "JSON/characters.json";
        static List<Character> Characters;

        public static void CharacterJsonCheck()
        {
            if (!File.Exists(CharacterFile)) 
            {
                File.Copy(BaseFile, CharacterFile);
            }; 
        }

        public static List<Character> ReadFile()
        {
            string jsonString = File.ReadAllText(CharacterFile);
            var characterJSON = JsonConvert.DeserializeObject<List<Character>>(jsonString);
            Characters = characterJSON;
            return characterJSON;
        }

        public static void WriteFile(Character character)
        {
            var updatedCharacters = JsonConvert.SerializeObject(Characters, Formatting.Indented);
            File.WriteAllText(CharacterFile, updatedCharacters);
        }
    }
}