using DeltaLifeInsurance.Models.Inventory;
using DeltaLifeInsurance.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DeltaLifeInsurance.Controllers
{
    public class UnitController : Controller
    {
        private readonly ILogger<UnitController> _logger;
        private readonly IGenericRepository<Unit> _unitRepository;

        public UnitController(ILogger<UnitController> logger,
          IGenericRepository<Unit> unitRepository )
        {
            _logger = logger;
            _unitRepository = unitRepository;           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Unit> _list = await _unitRepository.List();
            return View(_list);                
        }
    }
}
