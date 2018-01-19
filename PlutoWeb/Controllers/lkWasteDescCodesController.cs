using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class lkWasteDescCodesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public lkWasteDescCodesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult LoadWasteDescCodes(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;



            model.FirstLetters = _unitOfWork.WasteDescCodes.GetFirstLetter();


            model.WasteDescCodesPaging = _unitOfWork.WasteDescCodes.LkWasteDescCodeIndex(selectedLetter).ToList();

            


            return View(model);

        }
        // GET: lkWasteDescCodes
        public ActionResult Index()
        {
            return View();
        }

        // GET: lkWasteDescCodes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: lkWasteDescCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lkWasteDescCodes/Create
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

        // GET: lkWasteDescCodes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: lkWasteDescCodes/Edit/5
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

        // GET: lkWasteDescCodes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: lkWasteDescCodes/Delete/5
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
