using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theWorld1_5.Services;
using theWorld1_5.ViewModels;

namespace theWorld1_5.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModels model)
        {
            _mailService.SendMail("shawn@aol.com", model.Email, "From theWorld", model.Message);

            return View();
        }

        public IActionResult About()

        {
            return View();
        }
    }
}
