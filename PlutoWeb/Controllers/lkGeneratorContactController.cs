using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class lkGeneratorContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public lkGeneratorContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult LoadGeneratorContacts(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;

            model.FirstLetters = _unitOfWork.GeneratorContacts.GetFirstLetter();

            model.GeneratorContactPaging = _unitOfWork.GeneratorContacts.LkGeneratorContactIndex(selectedLetter).ToList();

            return View(model);

        }
        // GET: lkGeneratorContact
        public ActionResult Index()
        {
            return View();
        }

        // GET: lkGeneratorContact/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkGeneratorContact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkGeneratorContact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: lkGeneratorContact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkGeneratorContact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: lkGeneratorContact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkGeneratorContact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
