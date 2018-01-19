using PlutoWeb.Core;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;
using System;
using System.Linq;
using System.Web.Mvc;
using PlutoWeb.Models;
using System.Collections.Generic;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Persistence.Repositories;

namespace PlutoWeb.Controllers
{
    public class WasteDocketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public WasteDocketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public ActionResult GetDocket()
        //{

        //   /* List<tblLandFillDocket> landFilleDockets*/ = new List<tblLandFillDocket>();

        //    ILfDocketRepository docket = new LfDocketRepository();



        //    List<tblLandFillDocket> landFilleDockets = docket.GetDocket(47).ToList();
        //    //_unitOfWork.WasteDockets.GetDocket(Id);



        //    return View(landFilleDockets);
        //}

        public ActionResult GetDocket()
        {
            ILfDocketRepository docket = new LfDocketRepository();
            List<tblLandFillDocket> landFilleDockets = docket.GetDocket(47).ToList();

            return View(landFilleDockets);
        }

        // GET: WasteDocket
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Createt()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }
    }
}
//_unitOfWork.WasteDockets.GetDocket(Id);

//_unitOfWork.WasteDockets.GetDocket(Id).ToList();
//try
//{https://www.google.ca/search?q=mvc+unit+of+work+without+entity+framework&ei=1mMbWq6uKJTsjwOvmKu4Bw&start=0&sa=N&biw=1440&bih=767
//    var vandFilleDockets = _unitOfWork.WasteDockets.GetDocket(Id).ToList();
//} catch
// (NullReferenceException ex)
//{https://www.codeproject.com/Articles/160441/Using-C-Interfaces-to-Make-Applications-Resilient
//    ex.ToString();
//}https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
//_unitOfWork.WasteDockets.GetDocket(47);