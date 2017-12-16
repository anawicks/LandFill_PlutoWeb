using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class lkSubstanceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public lkSubstanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: lkSubstance
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadSubstances(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;



            model.FirstLetters = _unitOfWork.Substances.GetFirstLetter();


            model.SubstancePaging = _unitOfWork.Substances.LkSubstanceIndex(selectedLetter).ToList(); 


            return View(model);

        }

        // GET: lkSubstance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkSubstance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkSubstance/Create
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

        // GET: lkSubstance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkSubstance/Edit/5
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

        // GET: lkSubstance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkSubstance/Delete/5
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
