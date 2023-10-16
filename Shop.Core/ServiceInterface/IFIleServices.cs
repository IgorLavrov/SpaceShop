using Shop.Core.Domain;
using Shop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
        Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dto);


    }
}
