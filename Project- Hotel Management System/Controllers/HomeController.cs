using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Project__Hotel_Management_System.Controllers
{
    public class HomeController : Controller
    {   
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View();
        }
        
	}
}