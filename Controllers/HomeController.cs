using Logic_Heights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Logic_Heights.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

          
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

       
        public ActionResult Team()
        {
            ViewBag.Message = "Your app description page.";

            return View();

        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Blog()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult InProcess()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }


        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact(ContactModel Model)
        {
            ContactModel tempForm = new ContactModel();
            if (ModelState.IsValid)
            {
                EMail oMail = new EMail();

                if (oMail.SendMail(Model))
                {
                    TempData["AlertMessage"] = "Thank You! " + Model.Name + " for Contacting Us";
                }
                ModelState.Clear();
                return View(tempForm);
               }

            TempData["AlertMessage"] = "Please fill the form correctly and completly...";

            ModelState.Clear();
            return View(tempForm);
        }




        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Contact(ContactModel Model)
        //{
           
        //        if (ModelState.IsValid)
        //        {
        //            string Text = "<html> <head> </head>" +
        //            " <body style= \" font-size:12px; font-family: Arial; color:orange\">" +
        //            Model.Message + "<br><br><br><br>" + "From: <br><font color=\"#2c3e50\">" + Model.Name + "<br>" + Model.Email + "<br>" + Model.Phone +
        //            "</font></body></html>";

        //            if (SendEmail("support@logicheights.com", Text,"Query", Model.Email))
        //            {
        //                TempData["AlertMessage"] = "Thank You! " + Model.Name + " for Contacting Us";
        //            }
        //            ModelState.Clear();
        //            ContactModel tempForm = new ContactModel();
        //            return View(tempForm);
        //        }
       

        //    return View();
        //}


        //public static bool SendEmail(string SentTo, string Text, string Subject, string From)
        //{


        //    MailMessage msg = new MailMessage();

        //    msg.From = new MailAddress(From);
        //    msg.To.Add(SentTo);
        //    msg.Subject = "Logic Heights :" + Subject;
        //    msg.Body = Text;
        //    msg.Priority = MailPriority.High;
        //    msg.IsBodyHtml = true;

        //    SmtpClient client = new SmtpClient("mail.logicheights.com", 25);



        //    client.UseDefaultCredentials =true;
        //    client.EnableSsl = true;
        //    client.Credentials = new NetworkCredential("support@logicheights.com", "itlogicheights");
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;

        //    try
        //    {
        //        client.Send(msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}