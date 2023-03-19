using Microsoft.AspNetCore.Mvc;
using MyHermitage.Core.Dto;
using MyHermitage.Core.ServiceInterface;
using MyHermitage.Data;
using MyHermitage.Models.House;

namespace MyHermitage.Controllers
{
    public class HouseController : Controller
    {
        private readonly MyHermitageDbContext _context;
        private readonly IHouseServices _services;

        public HouseController(MyHermitageDbContext context, IHouseServices services)
        {
            _context = context;
            _services = services;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var result = _context.House
                .OrderByDescending(y => y.DateOfBildingPermition)
                .Select(x => new HouseListViewModel
                {
                    Id = x.Id,
                    ClientName = x.ClientName,
                    Address = x.Address,
                    Architecture = x.Architecture,
                    Size = x.Size,
                    NumberOfStoreys = x.NumberOfStoreys,
                    DateOfBildingPermition = x.DateOfBildingPermition
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            HouseEditViewModel house = new HouseEditViewModel();

            return View("CreateUpdate", house);
        }

        [HttpPost]
        public async Task<IActionResult> Create(HouseViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                ClientName = vm.ClientName,
                Address = vm.Address,
                Architecture = vm.Architecture,
                TypeOfBuilding = vm.TypeOfBuilding,
                Size = vm.Size,
                NumberOfStoreys = vm.NumberOfStoreys,
                BildingMaterial = vm.BildingMaterial,
                DateOfBildingPermition = vm.DateOfBildingPermition,
            };

            var result = await _services.Create(dto);

            if (result is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Update(Guid id)
        {
            var house = await _services.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseEditViewModel();

            vm.Id = house.Id;
            vm.ClientName = house.ClientName;
            vm.Address = house.Address;
            vm.Architecture = house.Architecture;
            vm.TypeOfBuilding = house.TypeOfBuilding;
            vm.Size = house.Size;
            vm.NumberOfStoreys = house.NumberOfStoreys;
            vm.BildingMaterial = house.BildingMaterial;
            vm.DateOfBildingPermition = house.DateOfBildingPermition;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(HouseEditViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                ClientName = vm.ClientName,
                Address = vm.Address,
                Architecture = vm.Architecture,
                TypeOfBuilding = vm.TypeOfBuilding,
                Size = vm.Size,
                NumberOfStoreys = vm.NumberOfStoreys,
                BildingMaterial = vm.BildingMaterial,
                DateOfBildingPermition = vm.DateOfBildingPermition,

            };

            var result = await _services.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _services.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseViewModel();

            vm.Id = house.Id;
            vm.ClientName = house.ClientName;
            vm.Address = house.Address;
            vm.Architecture = house.Architecture;
            vm.TypeOfBuilding = house.TypeOfBuilding;
            vm.Size = house.Size;
            vm.NumberOfStoreys = house.NumberOfStoreys;
            vm.BildingMaterial = house.BildingMaterial;
            vm.DateOfBildingPermition = house.DateOfBildingPermition;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {

            var product = await _services.Delete(id);

            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
