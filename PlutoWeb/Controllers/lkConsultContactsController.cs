using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class lkConsultContactsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public lkConsultContactsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult LoadConsultContacts(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;

            model.FirstLetters = _unitOfWork.ConsultContacts.GetFirstLetter();

             

            model.ConsultContactPaging = _unitOfWork.ConsultContacts.LkConsultContactIndex(selectedLetter).ToList();


            return View(model);

        }
        // GET: lkConsultContacts
        public ActionResult Index()
        {
            return View();
        }

        // GET: lkConsultContacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkConsultContacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkConsultContacts/Create
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

        // GET: lkConsultContacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkConsultContacts/Edit/5
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

        // GET: lkConsultContacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkConsultContacts/Delete/5
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
