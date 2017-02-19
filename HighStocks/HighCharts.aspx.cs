using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HighStocks.Models;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;

namespace HighStocks
{
    public partial class HighCharts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        public static ReportData GetReportData()
        {
            Dictionary<DateTime, decimal> obj = new Dictionary<DateTime, decimal>();
            DataSet ds = ExecuteDataSet("getReport");
            ReportData result = new ReportData();
            result.Report1 = Common.ConvertDataTableToList<Report>(ds.Tables[0]);
            result.Report2 = Common.ConvertDataTableToList<Report>(ds.Tables[1]);
            var rpt1 = from d1 in ds.Tables[0].AsEnumerable() select new string[] {Convert.ToString(d1[1]),Convert.ToString(d1[2]) };
            var rpt2 = from d2 in ds.Tables[0].AsEnumerable() select new string[] { Convert.ToString(d2[1]), Convert.ToString(d2[2]) };
            var a = from c in result.Report1 select new string[]{ c.ReportDate.ToString(),Convert.ToString(c.ReportAmount) };

            //string[] abtest = new string[]{ rpt1, rpt2 };
            
            return result;
        }

        [WebMethod]
        public static string getString()
        {
            return "this is the Test string";
        }
        
        private static DataSet ExecuteDataSet(string ProcedureName)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand(ProcedureName,con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
    }
}