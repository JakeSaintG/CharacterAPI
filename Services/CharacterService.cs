using System;
using CharacterAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace CharacterAPI.Services
{
    public static class CharacterService
    {
        static List<Character> Characters { get; }

        //=====================ADDRESS DISCLAIMERS=====================
        //Address used for all of the Beatles, including Pete, is the Ed Sullivan theater in New York (The Late Show). 
        //Address for John Wayne is the John Wayne Airport
        //Address for George Clooney is his fan mail office.
        //Address for Tina Turner and Joan Jett set to Hollywood Walk of Fame


        static CharacterService()
        {
            Characters = JSONService.ReadFile();
        }

        public static List<Character> GetAll() 
        {
            foreach (var item in Characters)
            {
                string imageUrl = "";
                //Allows for multiple image extensions to be returned by ID.
                if (File.Exists(@$"img/{item.Id}.webp"))
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/{item.Id}.webp";
                }
                else if (File.Exists(@$"img/{item.Id}.jpg"))
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/{item.Id}.jpg";
                }
                else if (File.Exists(@$"img/{item.Id}.png"))
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/{item.Id}.png";
                }
                else
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/imageNotFound.jpg";
                }
                item.Image = imageUrl;   
            }
            return Characters;
        }

        //Return a list of all characters stored in memory.
        public static List<Character> Get(string name)
        {
            var searchResults = new List<Character>{};
            foreach (var item in Characters)
            {
                item.BirthDate.ToShortDateString();
                string imageUrl = "";
                if (File.Exists(@$"img/{item.Id}.webp"))
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/{item.Id}.webp";
                }
                else if (File.Exists(@$"img/{item.Id}.png"))
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/{item.Id}.png";
                }
                else if (File.Exists(@$"img/{item.Id}.jpg"))
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/{item.Id}.jpg";
                }
                else
                {
                    imageUrl = $"http://localhost:5000/CharacterImage/imageNotFound.jpg";
                }

                if (item.Name.Contains(name))
                {
                    item.Image = imageUrl;
                    searchResults.Add(item);
                }
                
            } 
            return searchResults;
        }

        //Adds the sent character to the Characters list.
        public static void Add(Character character)
        {
            Characters.Add(character);
        }

        //Not yet implemented but it is intended to allow a user to delete a character from the front end.
        public static void Delete(string name)
        {
            var character = Get(name);
            if(character is null)
            {
                return;
            }
            Characters.Remove(character[0]);
        }
    }
}
