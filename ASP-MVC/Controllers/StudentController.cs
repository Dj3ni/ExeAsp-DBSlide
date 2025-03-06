using ASP_MVC.Handlers;
using ASP_MVC.Mapper;
using ASP_MVC.Models.Student;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentRepository<Student> _studentService;

		public StudentController(IStudentRepository<Student> studentService)
		{
			_studentService = studentService;
		}


		// GET: StudentController
		public ActionResult Index()
		{
			try
			{
				IEnumerable<StudentListItem> model = _studentService.GetAll().Select(bll => bll.ToListItem());
				return View(model);
			}
			catch (Exception)
			{

				return RedirectToAction("Index", "Home");
			}
		}

		// GET: StudentController/Details/5
		public ActionResult Details(int id)
		{
			try
			{
				StudentDetails model = _studentService.GetById(id).ToStudentDetails();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Index");
			}
		}

		// GET: StudentController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: StudentController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(StudentCreate form)
		{
			try
			{
				ModelState.MinAge((DateOnly)form.Birth_date, nameof(form.Birth_date));
				if(!ModelState.IsValid) throw new ArgumentException(nameof(form));
				int id = _studentService.Insert(form.ToBLL());

				return RedirectToAction("Details", new { id });
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentController/Edit/5
		public ActionResult Edit(int id)
		{
			Student student = _studentService.GetById(id);
			StudentUpdate model = student.ToEditForm();
			return View(model);
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, StudentUpdate form)
		{
			try
			{
				ModelState.MinAge((DateOnly)form.Birth_date, nameof(form.Birth_date));
				if(!ModelState.IsValid)throw new ArgumentException(nameof(form));

				_studentService.Update(id,form.ToBLL());
				return RedirectToAction(nameof(Details), new {id});
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentController/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
				StudentDelete model = _studentService.GetById(id).ToDeleteForm();
				return View(model);
			}
			catch (Exception)
			{

				return RedirectToAction("Error", "Home");
			}
		}

		// POST: StudentController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, StudentDelete form)
		{
			try
			{
				//No verification because no change
				_studentService.Delete(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
