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

        [HttpGet]
        public ActionResult<List<Person>> GetAll() =>
        PeopleService.GetAll();

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

        [HttpPost]
        public IActionResult Create(Person person)
        {            
            PeopleService.Add(person);
            return CreatedAtAction(nameof(Create), new { id = person.Id }, person);
        }

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