using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;

namespace PlutoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
         

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index(string selectedLetter)
        {

         
            var courses = _unitOfWork.Consultants.GetAll();



            return View(courses);
        }

        public ActionResult LoadConsultants(string selectedLetter)
        {

            var model = new AlphabeticalPagingViewModel();
            model.SelectedLetter = selectedLetter;

            model.FirstLetters = _unitOfWork.Consultants.GetFirstLetter();

            model.ConsultantPaging = _unitOfWork.Consultants.LkConsultantIndex(selectedLetter).ToList();







            return View(model);

        }
        public ActionResult HomeModelTest(string selectedLetter)
        {
          
                var model = new AlphabeticalPagingViewModel();
                model.SelectedLetter = selectedLetter;

                model.FirstLetters = _unitOfWork.Consultants.GetFirstLetter();

                model.ConsultantPaging = _unitOfWork.Consultants.LkConsultantIndex(selectedLetter).ToList();

                

            



             return View(model);
  
        }
        public ActionResult GetThisConsult(int id)
        {
            var selCons = _unitOfWork.Consultants.GetConsultant(50);

            return View(selCons);
        }
        [HttpPost]
        public ActionResult AddCourse()
        {
            _unitOfWork.Courses.Add(new Course
            {
                Name = "New Course at " + DateTime.Now.ToShortDateString(),
                Description = "Description",
                AuthorId = 1,
                FullPrice = 49,
                Level = 1
            });

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}