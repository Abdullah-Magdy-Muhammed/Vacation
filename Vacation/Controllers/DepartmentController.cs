using Microsoft.AspNetCore.Mvc;
using Vacation.DataAccess.IRepositories;
using Vacation.Models;

namespace Vacation.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public DepartmentController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var departments = await _unitOfWork.Department.GetAll();
			return View(departments);
		}
		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var department = await _unitOfWork.Department.GetFirstOrDefault(c => c.Id == id);
			if (department == null)
			{
				return NotFound();
			}
			return View(department);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(Department department)
		{
			if (ModelState.IsValid)
			{
				var departments = await _unitOfWork.Department.Update(department);
				TempData["success"] = "Department is updated successfully";
				return RedirectToAction(nameof(Index));
			}
			return View(department);
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Department department)
		{
			if (ModelState.IsValid)
			{
				await _unitOfWork.Department.Add(department);
				TempData["success"] = "Department is created successfully";
				return RedirectToAction(nameof(Index));
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == 0)
				return BadRequest();
			var department = await _unitOfWork.Department.GetFirstOrDefault(c => c.Id == id);
			if (department == null)
			{
				return NotFound();
			}
			else
			{
				var employeeToBeDeleted = await _unitOfWork.Department.Delete(department);
				if (employeeToBeDeleted)
					return Json(new { success = true, message = "Department Deleted Successfully!" });
				else
				{
					return Json(new { success = false, message = "Error While Deleting!" });
				}
			}
		}
	}
}
