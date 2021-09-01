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
    /*Note:
    Images posted to the "img" folder stay there. They are assigned a 9 digit, randomized name/ID from the front end.
    When images are retrieved, the ID in the accompanying JSON is matched to the image name and sent.
    The length of the random ID will hopefully not cause overlap/replaced files on a smaller scale use.
    */

    [ApiController]
    [Route("[controller]")]
    public class PeopleImageController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;

        public PeopleImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        
        //Returns requested image 
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

        //Posts sent images to "img" folder in root directory.
        [HttpPost]
        public string Post([FromForm] ImageUpload objectImage)
        {
            string path = @$"img/";
            try
            {
                if (objectImage.files.Length > 0)
                {                  
                    using (FileStream filestream = System.IO.File.Create(path + objectImage.files.FileName))
                    {
                        objectImage.files.CopyTo(filestream);
                        filestream.Flush(); //Clears buffers for this stream and causes any buffered data to be written to the file.
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