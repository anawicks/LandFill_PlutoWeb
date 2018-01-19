using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlutoWeb.Core.Domain;
using PlutoWeb.Persistence;



namespace PlutoWeb.Models
{
    public class HomeModel
    {
        public tblConsultants consultants { get; set; }

        public tblGenerators generators { get; set; }

        //public HomeModel(UnitOfWork unitOfWork, string selectedLetter)
        //{
        //    consultants = unitOfWork.Consultants.LkConsultantIndex(selectedLetter).ToList();




        //}
    }
}