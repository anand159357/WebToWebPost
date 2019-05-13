using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CallToServer(string field) {

            using (var client = new HttpClient())

            {
                var values = new Dictionary<string, string>
                {
                   { "FirstName", field }
                };

                var content = new FormUrlEncodedContent(values);
                client.BaseAddress = new Uri("http://localhost:56594/Home/PostData");
                var postTask = client.PostAsync(client.BaseAddress, content);
                postTask.Wait();
            }
            return Redirect("http://localhost:56594/Home/Index");
        }

        public void Receive() {
            var result = Request.Form.AllKeys;

        }
    }
}