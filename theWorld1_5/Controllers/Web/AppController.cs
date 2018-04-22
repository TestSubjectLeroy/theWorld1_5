using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theWorld1_5.Models;
using theWorld1_5.Services;
using theWorld1_5.ViewModels;

namespace theWorld1_5.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService,
            IConfigurationRoot config,
            IWorldRepository repository,
              ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

        }

        [Authorize]
        public IActionResult Trips()
        {
            try
            {
                var trips = _repository.GetAllTrips();
                return View(trips);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failrd to get trips in page:{ex.Message}");
                return Redirect("/error");
                
            }
          

        }




        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModels model)
        {

            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From theWorld", model.Message);
            }
            return View();
        }

        public IActionResult About()

        {
            return View();
        }
    }
}
