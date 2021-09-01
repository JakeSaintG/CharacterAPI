using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Models;
using PeopleAPI.Services;


namespace PeopleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        public PeopleController()
        {
        }
        
        //Gets all people stored and sends it.
        [HttpGet]
        public ActionResult<List<Person>> GetAll() =>
        PeopleService.GetAll();

        //Gets a person by name and returns their information.
        [HttpGet("{name}")]
        public ActionResult<List<Person>> Get(string name)
        {
            var person = PeopleService.Get(name.ToLower());
            if(!person.Any())
            {
                return NotFound();
            } 
            else 
            {
                return person;
            }                   
        }

        //Creates a person object, adds them to memory, and returns Created action.
        [HttpPost]
        public IActionResult Create(Person person)
        {            
            PeopleService.Add(person);
            return CreatedAtAction(nameof(Create), new { id = person.Id }, person);
        }

        //Not yet implemented but it is intended to allow a user to delete a person from the front end.
        [HttpDelete("{id}")]
        public IActionResult Delete(string name)
        {
            var person = PeopleService.Get(name);
            if (person is null)
            {
                return NotFound();
            }
            PeopleService.Delete(name);
            return NoContent();
        }
    }
}