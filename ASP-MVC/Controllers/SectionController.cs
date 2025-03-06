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
		public ActionResult Create(SectionCreate form)
		{
			try
			{
				if(!ModelState.IsValid)throw new ArgumentException(nameof(form));
				int id = _sectionService.Insert(form.ToBLL());
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
			SectionEdit model = _sectionService.GetById(id).ToEdit();
			return View(model);
		}

		// POST: SectionController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, SectionEdit form)
		{
			try
			{
				if(!ModelState.IsValid) throw new ArgumentException(nameof(form));
				_sectionService.Update(id, form.ToBLL());
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
			SectionDelete model = _sectionService.GetById(id).ToDeleteForm();
			return View(model);
		}

		// POST: SectionController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, SectionDelete form)
		{
			try
			{
				_sectionService.Delete(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
