using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.BusinessLogicLayer.ExcelSheetProcessor;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npoi.Mapper;
using UI.Models;

namespace UI.Controllers
{
    public class FileUploadController : Controller
    {

        [HttpPost]
        public IActionResult FileUploadIndex(List<IFormFile> files) {

            // TO DO: AT LEAST VALIDATE FILE SIGNATURES ...

            ExcelFileProcessor fileProc = new ExcelFileProcessor();
            IEnumerable<PersonModel> table = null;

            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files) {
                if (formFile.Length > 0) {
                   table =  fileProc.ImportExcelFormFile(formFile);
                }
            }

            List<PersonViewModel> viewList = new List<PersonViewModel>();
            foreach(var row in table) {
                viewList.Add(row);
            }

            return PartialView("_CustomDataTable", viewList);
            //return Ok(new { count = files.Count, size, filePaths });
            
        }
    }
}