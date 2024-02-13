using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vacation.DataAccess.IRepositories;
using Vacation.DataAccess.Repositories;
using Vacation.Models;

namespace Vacation.Controllers
{
	public class VacationController : Controller
	{
        private readonly IUnitOfWork _unitOfWork;

        public VacationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
		{
            var vacations = await _unitOfWork.Vacation.GetAll(IncludeProperties: "Department");
            return View(vacations);
        }
        [HttpGet]
        public IActionResult Create ( )
        {
            ViewData["DepartmentId"] = new SelectList((_unitOfWork.Department.GetAllAsQueryable().ToList()).Select(x => new { Id = x.Id, Title = x.Name }), "Id", "Title");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Vacations model)
        {
            var result = await _unitOfWork.Vacation.Add(model);
            if (result)
            {
                TempData["success"] = "Vacation is created successfully";
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> VacationDetails(int? id)
        {
            var currentVaction = await _unitOfWork.Vacation.GetFirstOrDefault(x=>x.Id == id,IcludeProperties:"Department");
            if (currentVaction == null)
            {
                return NotFound();
            }
            else
            {
                return View(currentVaction);

            }

        }
    }
}
