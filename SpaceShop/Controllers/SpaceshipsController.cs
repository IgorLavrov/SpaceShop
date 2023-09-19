using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using SpaceShop.Models.Spaceship;

namespace SpaceShop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopContext _context;
        private readonly ISpaceshipServices _spaceshipServices;

        public SpaceshipsController(ShopContext context, ISpaceshipServices spaceshipServices)
        {
            _context = context;
            _spaceshipServices = spaceshipServices;
        }

        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipIndexViewModel {

                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    EnginePower = x.EnginePower,
                    Passengers = x.Passengers

                });

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipCreateUpdateViewModel spaceship = new SpaceshipCreateUpdateViewModel();

            return View("CreateUpdate", spaceship);

        }

        [HttpPost]
        public async Task<IActionResult>Update(SpaceshipCreateUpdateViewModel vm){
            
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passengers = vm.Passengers,
                EnginePower = vm.EnginePower,
                Crew = vm.Crew,
                Company = vm.Company,
                CargoWeight = vm.CargoWeight,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,

            };
            var result= await _spaceshipServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index),vm); 

             

        }

        [HttpGet]
        public async Task<IActionResult>Delete(Guid id)
        {
            var spaceship= await _spaceshipServices.GetAsync(id);
              if(spaceship == null) {
            
            return NotFound();}
            var vm = new SpaceshipDeleteViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.Crew = spaceship.Crew;
            vm.Passengers = spaceship.Passengers;
            vm.EnginePower = spaceship.EnginePower;
            vm.Crew = spaceship.Crew;
            vm.Company = spaceship.Company;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult>DeleteConfirmation(Guid id)
        {
            var spaceshipId= await _spaceshipServices.GetAsync(id);

            if(spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm) {

            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passengers = vm.Passengers,
                EnginePower = vm.EnginePower,
                Crew = vm.Crew,
                Company = vm.Company,
                CargoWeight = vm.CargoWeight

            };

            var result = await _spaceshipServices.Create(dto);




            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipServices.GetAsync(id);
            
            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.Crew = spaceship.Crew;
            vm.Passengers = spaceship.Passengers;
            vm.EnginePower = spaceship.EnginePower;
            vm.Crew= spaceship.Crew;
            vm.Company = spaceship.Company;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;


            return  View(vm);
        }


        [HttpGet]
        public async Task<IActionResult>Update(Guid id)
        {

            var spaceship=await _spaceshipServices.GetAsync(id);
            if (spaceship == null) { 
             return NotFound();
            }
            var vm=new SpaceshipCreateUpdateViewModel();
            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.Crew = spaceship.Crew;
            vm.Passengers = spaceship.Passengers;
            vm.EnginePower = spaceship.EnginePower;
            vm.Crew = spaceship.Crew;
            vm.Company = spaceship.Company;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;

            return View("CreateUpdate",vm);

        }

    }

}
