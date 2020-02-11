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

namespace UI.Controllers
{
    public class FileUploadController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> FileUploadIndex(List<IFormFile> files) {

            // TO DO: AT LEAST VALIDATE FILE SIGNATURES MAN.. THIS IS WILD...

            ExcelFileProcessor fileProc = new ExcelFileProcessor();

            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files) {
                if (formFile.Length > 0) {
                     fileProc.ImportExcelFormFile(formFile);
                }
            }

            return Ok(new { count = files.Count, size, filePaths });
        }
    }
}