using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.BusinessLogicLayer.ExcelSheetProcessor;
using DataLibrary.DALC;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccountHome()
        {

            return View();
        }


        public IActionResult GetView(string viewName) {

    
            

            return PartialView(viewName);
        }

      
        public IActionResult ImportData(ImportDataViewModel model) {

            model.PersonList = new List<PersonViewModel>();
            model.UploadStats = new UploadStatsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult SearchData() {

            SearchDataModel model = new SearchDataModel ();
            model.Person = new PersonViewModel();

            PersonHelperMethodsDalc helperObject = new PersonHelperMethodsDalc();
            model.GenderTypes = helperObject.GetGenderTypes();
            model.MaritalStatusTypes = helperObject.GetMaritalStatusTypes();

            return View(model);
        }

        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> files) {

            ImportDataViewModel model = new ImportDataViewModel();
            model.PersonList = new List<PersonViewModel>();
            model.UploadStats = new UploadStatsViewModel();

            // TO DO: AT LEAST VALIDATE FILE SIGNATURES ...
            try {
                ExcelFileProcessor fileProc = new ExcelFileProcessor();
                IEnumerable<PersonModel> table = null;

                long size = files.Sum(f => f.Length);

                var filePaths = new List<string>();
                foreach (var formFile in files) {
                    if (formFile.Length > 0) {
                        table = fileProc.ImportExcelFormFile(formFile);
                    }
                }

                
                foreach (var row in table) {
                    model.PersonList.Add(row);
                }

                model.UploadStats.NumberOfRecords = table.Count();
                model.UploadStats.FileName = files[0].FileName;
      
            }catch(Exception e) {
                // TO DO
            }

            return View("ImportData", model);

            // return RedirectToAction("ImportData", viewList);
        }

    }
}