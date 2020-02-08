using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.BusinessLogicLayer.PersonUtilities;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult AccountHome()
        {
            return View();
        }

    }
}