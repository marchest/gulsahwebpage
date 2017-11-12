using System;
using System.Net.Http;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mime;
using System.Web.Services;

namespace gulsahWebProj
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }


     
        protected void sendMessage(object sender, EventArgs e)
        {
               try
            {
                MailMessage mailMsg = new MailMessage();
              
                mailMsg.To.Add(new MailAddress("gulsah.samut@ceng.deu.edu.tr", "Gulsah"));

              
                mailMsg.From = new MailAddress(Request.Form["Email"], Request.Form["NAME"]);

             
                mailMsg.Subject = "İletişime geçmek isteyen birisi var";
                string text = Request.Form["message"];
                string html = @"<p>Furkan seni seviyor</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

           
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("apikey", "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");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
    
}