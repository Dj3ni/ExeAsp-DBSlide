using ASP_MVC.Mapper;
using ASP_MVC.Models.Section;
using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
	public class SectionController : Controller
	{
		//Service Injection
		private readonly ISectionRepository<Section> _sectionService;

		public SectionController(ISectionRepository<Section> sectionService)
		{
			_sectionService = sectionService;
		}


		// GET: SectionController
		public ActionResult Index()
		{
			try
			{
				IEnumerable<SectionListItem> model = _sectionService.GetAll().Select(bll=>bll.ToListItem());

				return View(model);
			}
			catch (Exception)
			{

				return RedirectToAction("Index", "Home");
			}
		}

		// GET: SectionController/Details/5
		public ActionResult Details(int id)
		{
			try
			{
				SectionDetails model = _sectionService.GetById(id).ToDetails();
				return View(model);
			}
			catch (Exception)
			{
				return RedirectToAction("Index");
			}
		}

		// GET: SectionController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SectionController/Create
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

		// GET: SectionController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SectionController/Edit/5
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

		// GET: SectionController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SectionController/Delete/5
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
