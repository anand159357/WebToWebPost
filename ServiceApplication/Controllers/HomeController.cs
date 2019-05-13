using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ServiceApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public void PostData()
        {
            ViewBag.Message = Request.Form[0].ToString();
        }

        public ActionResult CallToClient() {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "FirstName", "Pankaj" }
                };

                var content = new FormUrlEncodedContent(values);

                client.BaseAddress = new Uri("http://localhost:56527/Home/Receive");
                var postTask = client.PostAsync(client.BaseAddress, content);
                postTask.Wait();
            }

            return Redirect("http://localhost:56527/Home/Receive");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}