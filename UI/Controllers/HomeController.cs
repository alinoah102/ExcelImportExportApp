using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;
using DataLibrary.Models;
using DataLibrary.DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace UI.Controllers {
    public class HomeController : Controller {

        

        public IActionResult Login() {

          
            return View();
        }

        [HttpGet]
        public IActionResult Registration() {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel viewModel) {

            UserModel model = new UserModel();
            model.UserName = viewModel.UserName;
            model.EmailAddress = viewModel.EmailAddress;
            string test = DatabaseHelper.ConnectionStringGet();

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
