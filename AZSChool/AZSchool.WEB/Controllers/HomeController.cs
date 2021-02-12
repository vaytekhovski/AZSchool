using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AZSchool.WEB.Models;

namespace AZSchool.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            LoginModel loginModel = new LoginModel()
            {
                Error = "",
                Login = "",
                Password = "",
            };
            return View(loginModel);
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(model.Login == model.Password)
            {
                if(model.Login == "teacher")
                    return RedirectToAction("Teacher", "Home");
                else if(model.Login == "student")
                    return RedirectToAction("Student", "Home");
            }
            model.Error = "Не верный пароль!";
            return View(model);
        }

        public IActionResult Student()
        {
            return View();
        }

        public IActionResult Student_InProgress()
        {
            return View();
        }

        public IActionResult Student_Done()
        {
            return View();
        }
        public IActionResult Teacher()
        {
            return View();
        }

        public IActionResult Teacher_InProgress()
        {
            return View();
        }

        public IActionResult Teacher_Done()
        {
            return View();
        }
    }
}
