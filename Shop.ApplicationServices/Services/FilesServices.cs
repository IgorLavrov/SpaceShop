using Microsoft.Extensions.Hosting;
using Shop.Core.Domain;
using Shop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
   public class FilesServices
    {
        //{
        private readonly IHostEnvironment _webHost;

        public FilesServices(
            IHostEnvironment webHost
            )
        {
            _webHost = webHost;




        }
        


        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {

            if (dto.Files != null && dto.Files.Count > 0)
            {
            if (!Directory.Exists(_webHost.ContentRootPath+"\\multipleFileUpload\\"))
            {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");

                }



            foreach (var image in dto.Files)
            {
                    string uploadsFolder=Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");
                    string uniqueFileName= Guid.NewGuid().ToString()+"_" +image.FileName;
                    string filePath=Path.Combine(uploadsFolder,uniqueFileName);


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    { 
                    image.CopyTo(fileStream);
                    
                    }

                }


        }
    }
    }
}
