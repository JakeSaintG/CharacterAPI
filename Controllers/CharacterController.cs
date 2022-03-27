using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CharacterAPI.Models;
using CharacterAPI.Services;


namespace CharacterAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        public CharacterController()
        {
        }
        
        //Gets all characters stored and sends it.
        [HttpGet]
        public ActionResult<List<Character>> GetAll() =>
        CharacterService.GetAll();

        //Gets a character by name and returns their information.
        [HttpGet("{name}")]
        public ActionResult<List<Character>> Get(string name)
        {
            var character = CharacterService.Get(name.ToLower());
            if(!character.Any())
            {
                return NotFound();
            } 
            else 
            {
                return character;
            }                   
        }

        //Creates a character object, adds them to memory, and returns Created action.
        [HttpPost]
        public IActionResult Create(Character character)
        {            
            CharacterService.Add(character);
            return CreatedAtAction(nameof(Create), new { id = character.Id }, character);
        }

        //Not yet implemented but it is intended to allow a user to delete a character from the front end.
        [HttpDelete("{id}")]
        public IActionResult Delete(string name)
        {
            var character = CharacterService.Get(name);
            if (character is null)
            {
                return NotFound();
            }
            CharacterService.Delete(name);
            return NoContent();
        }
    }
}