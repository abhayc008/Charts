using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HighStocks
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testFlipDataTable();
        }

        private static DataTable testFlipDataTable()
        {
            DataTable dt = new DataTable();
            for (int i = 1; i < 21; i++)
                dt.Columns.Add("Col" + i.ToString());
            for (int i = 1; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < 20; j++)
                {
                    dr[j] = "row"+i.ToString() + j.ToString();
                }

                dt.Rows.Add(dr);

            }

           return flipdata(dt);

        }

        protected static DataTable flipdata(DataTable dt)
        {
            DataTable result = new DataTable();

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                DataRow dr = result.NewRow();
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        { result.Columns.Add(dt.Columns[0].ColumnName);
                        result.Columns.Add(dt.Rows[j][i].ToString());
                        }
                        else
                            result.Columns.Add(dt.Rows[j][i].ToString());
                    }
                    else
                    {
                        
                        if (j == 0)
                        {
                            dr[j] = (dt.Columns[i].ColumnName);
                            dr[j+1] = (dt.Rows[j][i].ToString());
                        }
                        else
                            dr[j+1] = (dt.Rows[j][i].ToString());

                        
                    }
                }
                if(i != 0)
                    result.Rows.Add(dr);

            }
            return result;
        }
        
        [WebMethod]
        public static string GetData()
        {
            string str = string.Empty;
            DataTable dt = testFlipDataTable();
            str = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return str;
        }
    }
}