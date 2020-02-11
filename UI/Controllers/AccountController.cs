using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccountIndex()
        {

            return View();
        }

        public IActionResult ImportData() {


            return View();
        }

        public IActionResult SearchData() {

            List<PersonViewModel> listModel = new List<PersonViewModel>();

            listModel.Add(new PersonViewModel { City= "test" });

            return PartialView("_SearchData", listModel);
        }

        public IActionResult ExportData() {


            return View();
        }

        public IActionResult GetView(string viewName) {



            return PartialView(viewName);
        }

    }
}