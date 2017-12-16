using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class lkGeneratorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public lkGeneratorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: lkGenerator
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadGenerators(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;

            model.FirstLetters = _unitOfWork.Generators.GetFirstLetter();
                 

            model.GeneratorPaging = _unitOfWork.Generators.LkGeneratorIndex(selectedLetter).ToList();
             

            return View(model);

        }
        // GET: lkGenerator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkGenerator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkGenerator/Create
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

        // GET: lkGenerator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkGenerator/Edit/5
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

        // GET: lkGenerator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkGenerator/Delete/5
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
