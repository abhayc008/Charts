using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Net.Http;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HighStocks
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test();
            //testFlipDataTable();
        }

        public void test()
        {
            try
            {
                using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    // Make sure to change API address
                    client.BaseAddress = new Uri("http://localhost:63515/");

                    var values = new[]
                            {
                                new KeyValuePair<string, string>("uploadData1", "Test Data 1"),
                                new KeyValuePair<string, string>("uploadData2", "Test Data 2")
                            };
                    foreach (var keyValuePair in values)
                    {
                        content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                    }
                    /*
                    // Add first file content 
                    var fileContent1 = new ByteArrayContent(File.ReadAllBytes(@"e:\Nirbhay_LIC.pdf"));
                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "Sample.pdf"
                    };

                    // Add Second file content
                    var fileContent2 = new ByteArrayContent(File.ReadAllBytes(@"e:\TEST.txt"));
                    fileContent2.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "Sample.txt"
                    };

                    content.Add(fileContent1);
                    content.Add(fileContent2);
                    */
                    // Make a call to Web API
                    var result = client.PostAsync("http://localhost:63515/api/upload/post", content).Result;

                    string strresult = (result.StatusCode.ToString());
                }
            }
            catch(Exception ex)
            {

            }
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
                    dr[j] = "row" + i.ToString() + j.ToString();
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
                        {
                            result.Columns.Add(dt.Columns[0].ColumnName);
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
                            dr[j + 1] = (dt.Rows[j][i].ToString());
                        }
                        else
                            dr[j + 1] = (dt.Rows[j][i].ToString());


                    }
                }
                if (i != 0)
                    result.Rows.Add(dr);

            }
            return result;
        }

        public void test1()
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    client.BaseAddress = new Uri("http://localhost:63515/");
                    var values = new[]
        {
            new KeyValuePair<string, string>("Foo", "Bar"),
            new KeyValuePair<string, string>("More", "Less"),
        };

                    foreach (var keyValuePair in values)
                    {
                        content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                    }

                    var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(@"E:\TEST.txt"));
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "Foo.txt"
                    };
                    content.Add(fileContent);

                    var requestUri = "http://localhost:63515/api/Image/Post";
                    var result = client.PostAsync(requestUri, content).Result;
                }
            }
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