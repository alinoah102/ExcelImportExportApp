using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult ExportData() {


            return View();
        }

    }
}