﻿using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Microsoft.EntityFrameworkCore;
using SpaceShop.Models.RealEstate;

using System.Net.NetworkInformation;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Authorization;

namespace SpaceShop.Controllers
{
    [Authorize]
    public class RealEstateController : Controller
    {

        private readonly ShopContext _context;
        private readonly IRealEstateServices _realEstatesServices;
        private readonly IFileServices _fileServices;



        public RealEstateController
            (
                ShopContext context,
                IRealEstateServices realEstates,
                IFileServices fileservices
       

       
            )
        {
            _context = context;
            _realEstatesServices = realEstates;
            _fileServices = fileservices;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Address = x.Address,
                    BuildingType = x.BuildingType,
                    RoomCount = x.RoomCount,
                    SizeSqrM = x.SizeSqrM
                });

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var photos = await _context.FileToDatabases
               .Where(x => x.RealEstateId == id)
               .Select(y => new ImageToDatabaseViewModel
               {
                   RealEstateId = y.Id,
                   ImageId = y.Id,
                   ImageData = y.ImageData,
                   ImageTitle = y.ImageTitle,
                   Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
               }).ToArrayAsync();

            var vm = new RealEstateDetailsViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.SizeSqrM = realEstate.SizeSqrM;
            vm.RoomCount = realEstate.RoomCount;
            vm.Floor = realEstate.Floor;
            vm.BuildingType = realEstate.BuildingType;
            vm.BuiltInYear = realEstate.BuiltInYear;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.UpdatedAt = realEstate.UpdatedAt;
            vm.Image.AddRange(photos);

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel vm = new();

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                SizeSqrM = vm.SizeSqrM,
                RoomCount = vm.RoomCount,
                Floor = vm.Floor,
                BuildingType = vm.BuildingType,
                BuiltInYear = vm.BuiltInYear,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    RealEstateID = x.RealEstateId

                }).ToArray()
            };

            var result = await _realEstatesServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var photos= await _context.FileToDatabases
                .Where(x=> x.RealEstateId==id)
                .Select(y=>new ImageToDatabaseViewModel
                {
                    RealEstateId=y.Id,
                    ImageId=y.Id,
                    ImageData=y.ImageData,
                    ImageTitle=y.ImageTitle,
                    Image=string.Format("data:image/gif;base64,{0}",Convert.ToBase64String(y.ImageData))

            }).ToArrayAsync();

            var vm = new RealEstateCreateUpdateViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.SizeSqrM = realEstate.SizeSqrM;
            vm.RoomCount = realEstate.RoomCount;
            vm.Floor = realEstate.Floor;
            vm.BuildingType = realEstate.BuildingType;
            vm.BuiltInYear = realEstate.BuiltInYear;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.UpdatedAt = realEstate.UpdatedAt;
            vm.Image.AddRange(photos);


            return View("CreateUpdate", vm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto();

            dto.Id = vm.Id;
            dto.Address = vm.Address;
            dto.SizeSqrM = vm.SizeSqrM;
            dto.RoomCount = vm.RoomCount;
            dto.Floor = vm.Floor;
            dto.BuildingType = vm.BuildingType;
            dto.BuiltInYear = vm.BuiltInYear;
            dto.CreatedAt = vm.CreatedAt;
            dto.UpdatedAt = vm.UpdatedAt;
            dto.Files = vm.Files;
            dto.Image = vm.Image.Select(x => new FileToDatabaseDto
            {
                Id = x.ImageId,
                ImageData = x.ImageData,
                ImageTitle = x.ImageTitle,
                RealEstateID = x.RealEstateId

            }).ToArray();
           

        var result = await _realEstatesServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }
            var photos = await _context.FileToDatabases
                .Where(x => x.RealEstateId == id)
                .Select(y => new ImageToDatabaseViewModel
                {
                    RealEstateId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();

            var vm = new RealEstateDeleteViewModel();

            vm.Id = realEstate.Id;
            vm.Address = realEstate.Address;
            vm.SizeSqrM = realEstate.SizeSqrM;
            vm.RoomCount = realEstate.RoomCount;
            vm.Floor = realEstate.Floor;
            vm.BuildingType = realEstate.BuildingType;
            vm.BuiltInYear = realEstate.BuiltInYear;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.UpdatedAt = realEstate.UpdatedAt;
            vm.ImageToDatabase.AddRange(photos);


            return View(vm);

        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var realEstateId = await _realEstatesServices.Delete(id);

            if (realEstateId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task <IActionResult>RemoveImage(ImageToDatabaseViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
               
                Id=file.ImageId
            };

            var image=await _fileServices.RemoveImageFromDatabase(dto);


            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        public async Task<IActionResult>RemoveImages(Guid id)
        {

            var realEstate = await _realEstatesServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }
            var photos = await _context.FileToDatabases
                .Where(x => x.RealEstateId == id)
                .Select(y => new ImageToDatabaseViewModel
                {
                    RealEstateId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();

            var vm = new RealEstateDeleteViewModel();

          
            vm.ImageToDatabase.AddRange(photos);


            return View(vm);


        }
    }
}
// teha meetod ,mis kustutab mitu piltu korraga ara

