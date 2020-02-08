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


        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files) {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files) {
                if (formFile.Length > 0) {
                    ExcelFileProcessor.ImportExcelFormFile(formFile);
                }
            }

            return Ok(new { count = files.Count, size, filePaths });
        }
    }
}