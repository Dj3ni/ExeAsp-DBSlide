﻿using ASP_MVC.Mapper;
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
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: StudentController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: StudentController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: StudentController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
