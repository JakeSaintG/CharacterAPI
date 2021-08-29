using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Models;
using PeopleAPI.Services;
using System.Web;
using System.IO;

namespace PeopleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleImageController : ControllerBase
    {
        [HttpGet("{image}")]
        public ActionResult GetImage(string image)
        {
            string path = Directory.GetCurrentDirectory();
            var imageFolder = Path.GetDirectoryName(@$"{path}/img/");
            if (image == null)
            {
                return NotFound();
            } 
            var imageFile = Path.Combine(imageFolder, image);
            if (!System.IO.File.Exists(imageFile))
            {
                return NotFound();
            }
            return PhysicalFile(imageFile, "image/webp");
        }

        //[HttpPost]
        //public IActionResult Create(Person person)
        //{
        //    PeopleService.Add(person);
        //    return CreatedAtAction(nameof(Create), new { id = person.Id }, person);
        //}
    }
}