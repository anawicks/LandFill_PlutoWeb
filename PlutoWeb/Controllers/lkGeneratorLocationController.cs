using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class lkGeneratorLocationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public lkGeneratorLocationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult LoadGeneratorLocation(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;

            model.FirstLetters = _unitOfWork.GeneratorLocations.GetFirstLetter();

            model.GeneratorLocationPaging = _unitOfWork.GeneratorLocations.LkGeneratorLocationIndex(selectedLetter).ToList();

            return View(model);

        }
        // GET: lkGeneratorLocation
        public ActionResult Index()
        {
            return View();
        }

        // GET: lkGeneratorLocation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkGeneratorLocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkGeneratorLocation/Create
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

        // GET: lkGeneratorLocation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkGeneratorLocation/Edit/5
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

        // GET: lkGeneratorLocation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkGeneratorLocation/Delete/5
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
