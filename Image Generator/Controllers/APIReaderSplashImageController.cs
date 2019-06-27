using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using APIReader.Models;
using APIReader.SplashBaseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ImageGenerator;

namespace Image_Generator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIReaderSplashImageController : ControllerBase
    {
		private readonly SplashBaseService splashBaseService;
		private readonly ImageGeneratorService imageGeneratorService;
		private string fileName;

		public APIReaderSplashImageController(){
			splashBaseService = new SplashBaseService();
			imageGeneratorService = new ImageGeneratorService();
		}

		// GET: api/APIReaderSplashImage
		[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

		// GET: api/APIReaderSplashImage/laptop
		[Route("[action]/{value}")]
		[HttpGet("{value}", Name = "Get")]
        public SplashImages GetImageList(string value)
        {
			return splashBaseService.GetImagesBySearch(value);

			//return "value";
        }

		// GET: api/APIReaderSplashImage/GetImage/1
		[Route("[action]/{id}")]
		[HttpGet("{id}", Name = "GetImage")]
		public FileContentResult GetImageById(int id)
		{
			SplashImage img = splashBaseService.GetImageByID(id);
			byte[] imageBytes;

			using (var webClient = new WebClient())
			{
				imageBytes = webClient.DownloadData(img.url);
			}

			//Extract file name from URL
			fileName = imageGeneratorService.GetImageNameFromURL(img.url);

			System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
			{
				FileName = fileName,
				Inline = true,  // false = prompt the user for downloading;  true = browser to try to show the file inline
				CreationDate = DateTime.Today,
				ModificationDate = DateTime.Today
			};

			Response.Headers.Add("Content-Disposition", cd.ToString());
			Response.ContentLength = imageBytes.Length;
			Response.ContentType = "image/jpeg";
			var file = File(imageBytes, System.Net.Mime.MediaTypeNames.Application.Octet);
			return file;
		}

		// POST: api/APIReaderSplashImage
		[HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/APIReaderSplashImage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
