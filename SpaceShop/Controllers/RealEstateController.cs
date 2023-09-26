using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using SpaceShop.Models.RealEstate;
using System.Net.NetworkInformation;

namespace SpaceShop.Controllers
{
    public class RealEstateController : Controller
    {

            private readonly ShopContext _context;
            private readonly IRealEstateServices _realEstatesServices;

            public RealEstateController
                (
                    ShopContext context,
                    IRealEstateServices realEstates
                )
            {
                _context = context;
                _realEstatesServices = realEstates;
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
                var realEstate = await _realEstatesServices.DetailsAsync(id);

                if (realEstate == null)
                {
                    return NotFound();
                }

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
                var realEstate = await _realEstatesServices.DetailsAsync(id);

                if (realEstate == null)
                {
                    return NotFound();
                }

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
                var realEstate = await _realEstatesServices.DetailsAsync(id);

                if (realEstate == null)
                {
                    return NotFound();
                }

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
        }
    }

