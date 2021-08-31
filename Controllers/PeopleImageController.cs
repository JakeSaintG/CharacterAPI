using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PeopleAPI.Models;
using PeopleAPI.Services;
using System.Web;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace PeopleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleImageController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public PeopleImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        
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

        [HttpPost]
        public string Post([FromForm] ImageUpload objectImage)
        {
            string path = @$"img/";
            try
            {
                if ( objectImage.files.Length > 0)
                {                  
                    using (FileStream filestream = System.IO.File.Create(path + objectImage.files.FileName))
                    {
                        objectImage.files.CopyTo(filestream);
                        filestream.Flush();
                        return $"Image Uploaded";
                    }
                }
                else
                {
                    return "Image Upload Failed";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}