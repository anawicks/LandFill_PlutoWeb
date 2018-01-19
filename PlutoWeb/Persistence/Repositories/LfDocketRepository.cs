using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlutoWeb.Core.Domain;
using PlutoWeb.Core.Repositories;
using PlutoWeb.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
 

namespace PlutoWeb.Persistence.Repositories  
     
{
    public class LfDocketRepository :  ILfDocketRepository
    {
      
        
   
    
        public IEnumerable<tblLandFillDocket> GetDocket(int id)
        {
            
            int okId;

            if (id == 0)
                okId = 47;
            else
                okId = id;
            // return ConfigurationManager.ConnectionStrings["PlutoContext"].ConnectionString;
            string cn = ConfigurationManager.ConnectionStrings["PlutoContext"].ConnectionString;
            //dataAccess.ConnectionStringGet();

            SqlConnection con = new SqlConnection(cn);

            con.Open();
            //string cn = Cncontext.ConnectionStringGet();

            List<tblLandFillDocket> landFilleDockets = new List<tblLandFillDocket>();

            

            SqlCommand cmd = new SqlCommand("spDocketWasteGet", con);

            SqlParameter param = new SqlParameter();

            param.ParameterName = "@DocketId";
            param.Value = okId;

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(param);


            

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                tblLandFillDocket lfDockets = new tblLandFillDocket();

                lfDockets.InvoiceeId =0 +  Convert.ToInt16(rdr["InvoiceeId"]);
                lfDockets.DocketNo = "" + rdr["DocketNo"].ToString();
                lfDockets.WasteApprovalCode = "" + rdr["WasteApprovalCode"].ToString();
                lfDockets.InvoiceeId = 0 + Convert.ToInt16(rdr["InvoiceeId"]);
                lfDockets.TurckCompanyId = 0 + Convert.ToInt16(rdr["TurckCompanyId"]);
                lfDockets.DriverName = "" + rdr["DriverName"].ToString();
                lfDockets.DestinatedFor = "" + rdr["DestinatedFor"].ToString();
                lfDockets.ScaleTicket = "" + rdr["ScaleTicket"].ToString();
                lfDockets.ScaleGross = 0 + Convert.ToInt16(rdr["Gross"]);
                lfDockets.ScaleTare = 0 + Convert.ToInt16(rdr["Tare"]);
                lfDockets.ScaleNet = 0 + Convert.ToInt16(rdr["Net"]);

                lfDockets.Cell = "" + rdr["Cell"].ToString();
                lfDockets.GridLetter = "" + rdr["Grid"].ToString();
                lfDockets.GridNo = "" + rdr["GridNo"].ToString();
                lfDockets.Elevation = "" + rdr["Elevation"].ToString();
                lfDockets.DateReceived = Convert.ToDateTime(rdr["DateReceived"]);
                lfDockets.MemoText = "" + rdr["Memo"].ToString();
                lfDockets.InvoiceNo = "" + rdr["InvoiceNo"].ToString();
                if(!(rdr["LoadReceivingDate"] is DBNull))
                    lfDockets.DateReceived = Convert.ToDateTime(rdr["LoadReceivingDate"]);

                landFilleDockets.Add(lfDockets);
            }


             return landFilleDockets.ToList();




        }
     

    
    }
}