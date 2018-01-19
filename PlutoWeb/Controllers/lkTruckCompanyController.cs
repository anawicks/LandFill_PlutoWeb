using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{

    public class lkTruckCompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public lkTruckCompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult LoadTruckCompanies(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;

             

            model.FirstLetters = _unitOfWork.TruckCompanies.GetFirstLetter();
                 

            model.TruckCompanyPaging = _unitOfWork.TruckCompanies.LkTruckCompanyIndex(selectedLetter).ToList();

          
            return View(model);

        }
       
        // GET: lkTruckCompany
        public ActionResult Index()
        {
            return View();
        }

        // GET: lkTruckCompany/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkTruckCompany/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkTruckCompany/Create
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

        // GET: lkTruckCompany/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkTruckCompany/Edit/5
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

        // GET: lkTruckCompany/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkTruckCompany/Delete/5
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
