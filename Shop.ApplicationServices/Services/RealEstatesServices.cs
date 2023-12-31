﻿using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;


namespace Shop.ApplicationServices.Services
{
    public class RealEstatesServices: IRealEstateServices
   
        {

            private readonly ShopContext _context;
            private readonly IFileServices _fileServices;



        public RealEstatesServices
            (
                 ShopContext context,
                IFileServices fileServices

            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.SizeSqrM = dto.SizeSqrM;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.Floor = dto.Floor;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.BuiltInYear = dto.BuiltInYear;
            realEstate.CreatedAt = DateTime.Now;
            realEstate.UpdatedAt = DateTime.Now;

            if(dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realEstate);
            }
            
            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            realEstate.Id = dto.Id;
            realEstate.Address = dto.Address;
            realEstate.SizeSqrM = dto.SizeSqrM;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.Floor = dto.Floor;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.BuiltInYear = dto.BuiltInYear;
            realEstate.CreatedAt = dto.CreatedAt;
            realEstate.UpdatedAt = DateTime.Now;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto,realEstate);
            }

            _context.RealEstates.Update(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }


        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }


        public async Task<RealEstate> Delete(Guid id)
        {
            var result = await _context.RealEstates
              .FirstOrDefaultAsync(x => x.Id == id);

            var photos = await _context.FileToDatabases
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    RealEstateID= y.RealEstateId
                })
                .ToArrayAsync();

            await _fileServices.RemoveImagesFromDatabase(photos);
            _context.RealEstates.Remove(result);
            await _context.SaveChangesAsync();

           

            return result;
        }



    }

    }
