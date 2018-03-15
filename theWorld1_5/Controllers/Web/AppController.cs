using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theWorld1_5.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
