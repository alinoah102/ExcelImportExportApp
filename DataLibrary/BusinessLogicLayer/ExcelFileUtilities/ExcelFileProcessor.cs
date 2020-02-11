using System;
using System.Collections.Generic;
using System.Text;
using DataLibrary.DataAccessLayer;
using DataLibrary.Models;
using Dapper;
using GemBox.Spreadsheet;
using Npoi.Mapper;
using System.Linq;
using DataLibrary.DALC;
using Microsoft.AspNetCore.Http;

namespace DataLibrary.BusinessLogicLayer.ExcelSheetProcessor {
    public class ExcelFileProcessor {

        public void ImportExcelWorksheet(ExcelWorksheet worksheet) {

            // Extract the data from the worksheet to newly created DataTable starting at 
            // second row and first column (first row is for attributes)  until the first empty row appears.
            var dataTable = worksheet.CreateDataTable(new CreateDataTableOptions() {
                StartRow = 0,
                StartColumn = 0,
                ExtractDataOptions = ExtractDataOptions.StopAtFirstEmptyRow
            });

            // TO DO

        }

        public void ImportExcelFormFile(IFormFile file) {
            
            Mapper mapper = new Mapper(file.OpenReadStream());
            IEnumerable<PersonModel> data = mapper.Take<PersonModel>("data").Select(x => x.Value);

            PersonHelperMethodsDalc personHelperDalc = new PersonHelperMethodsDalc();
            PersonDalc personDalc = new PersonDalc();

            Dictionary<string, int> genderDict = personHelperDalc.GenderDictGet();
            Dictionary<string, int> maritalStatusDict = personHelperDalc.MartitalStatusDictGet();

            foreach (PersonModel m in data) {
                // Before Insert, map Gender/MaritalStatus names to IDs to match DB design
                m.GenderID = genderDict[m.Gender];
                m.MaritalStatusID = maritalStatusDict[m.MaritalStatus];

                personDalc.PersonInsert(m);
            }
        }

        public ExcelWorksheet ExcelWorksheetGet(string path) {
            try {
                // Load Excel file.
                var workbook = ExcelFile.Load(path);

                // Select active worksheet from the file.
                var worksheet = workbook.Worksheets.ActiveWorksheet;

                return worksheet;
            }catch(Exception e) {
                return null;

                // TO DO
            }
        }

       

    }
}
