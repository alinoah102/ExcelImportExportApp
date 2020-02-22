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


        // return list of inserted rows if successful
        public List<PersonModel> ImportExcelFormFile(IFormFile file) {

            PersonHelperMethodsDalc personHelperDalc = new PersonHelperMethodsDalc();
            PersonDalc personDalc = new PersonDalc();

            Dictionary<string, int> genderDict = personHelperDalc.GetGenderDictionary();
            Dictionary<string, int> maritalStatusDict = personHelperDalc.GetMaritalStatusDictionary();

            List<PersonModel> data = new List<PersonModel>();

            Mapper mapper = new Mapper(file.OpenReadStream());

            //IEnumerable<PersonModel> data = mapper.Take<PersonModel>("data").Select(x => x.Value);
            
            // map to dynamic type because GenderID and MaritalStatusID will be saved differently than what's in the excel sheet
            var objs = mapper.Take<dynamic>("data").ToList();

            foreach (var row in objs) {

                // create new PersonModel and map the excel sheet

                PersonModel newPerson = new PersonModel();

                newPerson.FirstName = row.Value.FirstName;
                newPerson.LastName = row.Value.LastName;
                newPerson.GenderID = genderDict[row.Value.Gender];
                newPerson.DateOfBirth = row.Value.DateOfBirth;
                newPerson.MaritalStatusID = maritalStatusDict[row.Value.MaritalStatus];
                newPerson.EmailAddress = row.Value.EmailAddress;
                newPerson.StreetAddressLine1 = row.Value.StreetAddressLine1;
                newPerson.StreetAddressLine2 = row.Value.StreetAddressLine2;
                newPerson.PhoneNumber = row.Value.PhoneNumber;
                newPerson.City = row.Value.City;
                newPerson.State = row.Value.State;
                newPerson.Zip = Convert.ToString(row.Value.Zip);
                
                data.Add(newPerson);


                personDalc.PersonInsert(newPerson);

            }

            return data;
        }

        public void ExportToExcel(List<PersonModel> modelList, string filename) {
            try {

                var mapper = new Mapper();

                PersonHelperMethodsDalc personHelper = new PersonHelperMethodsDalc();

                // reverse dictionaries for quicker look up O(1)
                Dictionary<int, string> genderDictReversed = personHelper.GetGenderDictionary().ToDictionary(x => x.Value, x => x.Key);
                Dictionary<int, string> maritalStatusDictReversed = personHelper.GetMaritalStatusDictionary().ToDictionary(x => x.Value, x => x.Key);

                

                mapper.Save(filename, modelList, "newSheet", overwrite: true);


            }
            catch(Exception e) {
               

                // TO DO
            }
        }

       

    }
}
