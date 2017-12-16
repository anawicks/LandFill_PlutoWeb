using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class lkConsultantController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public lkConsultantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: lkConsultant
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadConsultants(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;

            model.FirstLetters = _unitOfWork.Consultants.GetFirstLetter();


            model.ConsultantPaging = _unitOfWork.Consultants.LkConsultantIndex(selectedLetter).ToList();


            return View(model);

        }
        // GET: lkConsultant/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkConsultant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkConsultant/Create
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

        // GET: lkConsultant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkConsultant/Edit/5
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

        // GET: lkConsultant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkConsultant/Delete/5
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
