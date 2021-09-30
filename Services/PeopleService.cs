using System;
using PeopleAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace PeopleAPI.Services
{
    public static class PeopleService
    {
        static List<Person> People { get; }

        //=====================ADDRESS DISCLAIMERS=====================
        //Address used for all of the Beatles, including Pete, is the Ed Sullivan theater in New York (The Late Show). 
        //Address for John Wayne is the John Wayne Airport
        //Address for George Clooney is his fan mail office.
        //Address for Tina Turner and Joan Jett set to Hollywood Walk of Fame


        static PeopleService()
        {
            People = JSONService.ReadFile();
        }

        public static List<Person> GetAll() 
        {
            foreach (var item in People)
            {
                string imageUrl = "";
                //Allows for multiple image extensions to be returned by ID.
                if (File.Exists(@$"img/{item.Id}.webp"))
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/{item.Id}.webp";
                }
                else if (File.Exists(@$"img/{item.Id}.jpg"))
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/{item.Id}.jpg";
                }
                else if (File.Exists(@$"img/{item.Id}.png"))
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/{item.Id}.png";
                }
                else
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/imageNotFound.jpg";
                }
                item.Image = imageUrl;   
            }
            return People;
        }

        //Return a list of all people stored in memory.
        public static List<Person> Get(string name)
        {
            var searchResults = new List<Person>{};
            foreach (var item in People)
            {
                item.BirthDate.ToShortDateString();
                string imageUrl = "";
                if (File.Exists(@$"img/{item.Id}.webp"))
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/{item.Id}.webp";
                }
                else if (File.Exists(@$"img/{item.Id}.png"))
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/{item.Id}.png";
                }
                else if (File.Exists(@$"img/{item.Id}.jpg"))
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/{item.Id}.jpg";
                }
                else
                {
                    imageUrl = $"http://localhost:5000/PeopleImage/imageNotFound.jpg";
                }

                if (item.Name.Contains(name))
                {
                    item.Image = imageUrl;
                    searchResults.Add(item);
                }
                
            } 
            return searchResults;
        }

        //Adds the sent person to the People list.
        public static void Add(Person person)
        {
            People.Add(person);
        }

        //Not yet implemented but it is intended to allow a user to delete a person from the front end.
        public static void Delete(string name)
        {
            var person = Get(name);
            if(person is null)
            {
                return;
            }
            People.Remove(person[0]);
        }
    }
}
