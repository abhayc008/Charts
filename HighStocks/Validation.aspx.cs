using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HighStocks
{
    public partial class Validation : System.Web.UI.Page
    {
        TESTDataContext objTESTDataContext = new TESTDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindGrid();
            modalgrd.Show();
            //TestMail();
        }
        protected void bindGrid()
        {
            objTESTDataContext = new TESTDataContext();
            List<TEST2> lstData = objTESTDataContext.TEST2s.Where(t => t.Is_Active == true).ToList();

            GridView1.DataSource = lstData;
            GridView1.DataBind();
        }

        protected void TestMail()
        {
            try
            {
                string EmailFrom = "abhayc.0088@yahoo.com";
                string EmailTo = "abhayc.0088@yahoo.com"; // "abhayc.008@gmail.com";
                string PassWord = "nirbhay@008";
                string EmailHost = "smtp.mail.yahoo.com";
                string status = "";
                string Body = "";

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(EmailFrom);
                message.To.Add(new MailAddress(EmailTo));
                message.Subject = "Auto Backup at test";
                message.Body = "Backup has been taken at test on" + DateTime.Now;
                Body = "Backup has been taken at test on" + DateTime.Now;
                smtp.Port = 587;
                smtp.Host = EmailHost;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(EmailFrom, PassWord);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //ServiceLogLibrary.WriteErrorlog("Step:5");
                //Library.WriteErrorlog("Before sending mail");
                smtp.Send(message);
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "REDIRECT")
            {
                Response.Redirect("~/About.aspx");
            }
        }
    }
}