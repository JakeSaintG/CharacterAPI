using System;
using PeopleAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace PeopleAPI.Services
{
    public static class PeopleService
    {
        static List<Person> People { get; }

        static PeopleService()
        {
            People = new List<Person>
            {
                new Person { Id = 1, Name = "john lennon", BirthDate = new DateTime(1940, 10, 9), Address = new Address {Street = "1697 Broadway", City = "New York", State = "New York", Zip = 10019}, Interests = new string[] {"teachings of the Maharishi", "meditation", "music"}},
                new Person { Id = 2, Name = "paul mccartney", BirthDate = new DateTime(1942, 6, 18), Address = new Address {Street = "1697 Broadway", City = "New York", State = "New York", Zip = 10019}, Interests = new string[] {"composition", "The Quarrymen", "painting"}},
                new Person { Id = 3, Name = "ringo starr", BirthDate = new DateTime(1940, 7, 7), Address = new Address {Street = "1697 Broadway", City = "New York", State = "New York", Zip = 10019}, Interests = new string[] {"yellow submarines", "meditation", "music"}},
                new Person { Id = 4, Name = "george harrison", BirthDate = new DateTime(1943, 2, 25), Address = new Address {Street = "1697 Broadway", City = "New York", State = "New York", Zip = 10019}, Interests = new string[] {"hanging out with Bob Dylan", "Monty Python", "benefit concerts"}},
                new Person { Id = 5, Name = "pete best", BirthDate = new DateTime(1941, 11, 24), Address = new Address {Street = "1697 Broadway", City = "New York", State = "New York", Zip = 10019}, Interests = new string[] {"The drums", "movie production", "writing"}},
                //Address used for all of the Beatles, including Pete, is the Ed Sullivan theater in New York (The Late Show). 
                new Person { Id = 6, Name = "paul revere", BirthDate = new DateTime(1735, 1, 1), Address = new Address {Street = "19 N Square", City = "Boston", State = "massachusetts", Zip = 02113}, Interests = new string[] {"silversmithing", "revolution", "alerting the colonial militia"}},
                new Person { Id = 7, Name = "john wayne", BirthDate = new DateTime(1907, 5, 26), Address = new Address {Street = "18601 Airport Way", City = "Santa Ana,", State = "California", Zip = 92707}/*John Wayne Airport*/, Interests = new string[] {"Hollywood’s Golden Age", "football", "westerns"}},
                new Person { Id = 8, Name = "george clooney", BirthDate = new DateTime(1961, 5, 6), Address = new Address {Street = "10866 Wilshire Blvd. Suite 1100", City = "Los Angeles", State = "California", Zip = 90024}/*office*/, Interests = new string[] {"being batman", "tequila", "economic activism"}},
                //new Person { Id = 100, Name = "Template", BirthDate = new DateTime(YYYY, MM, DD), Address = new Address {Street = "Ave", City = "ville", State = "This One", Zip = 12345 }, Interests = new string[] {"OneWheel", "Cats", "Final Fantasy"}},
                new Person { Id = 9, Name = "tina turner", BirthDate = new DateTime(1939, 11, 26), Address = new Address {Street = "Hollywood Boulevard, Vine St", City = "Los Angeles", State = "California", Zip = 90028}, Interests = new string[] {"Mad Max", "The Sonny & Cher Show"}},
                //Address set to Hollywood Walk of Fame
                new Person { Id = 10, Name = "joan jett", BirthDate = new DateTime(1958, 9, 22), Address = new Address {Street = "Hollywood Boulevard, Vine St", City = "Los Angeles", State = "California", Zip = 90028}, Interests = new string[] {"WNBA", "PETA", "the United States Armed Forces"}},
                //Address set to Hollywood Walk of Fame
            };          
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
