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


        [HttpPost]
        public IActionResult UpdatePerson(SearchPersonViewModel model) {

            return null;
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

            SearchPersonViewModel model = new SearchPersonViewModel ();
            model.Person = new PersonViewModel();

            PersonHelperMethodsDalc helper = new PersonHelperMethodsDalc();
            // get a list of gender Names
            model.GenderTypes = helper.GetGenderDictionary().Keys.ToList();

            // get a list of marital status names
            model.MaritalStatusTypes = helper.GetMaritalStatusDictionary().Keys.ToList();


            return View(model);
        }

        [HttpPost]
        public IActionResult SearchData(SearchPersonViewModel model) {

            PersonHelperMethodsDalc helper = new PersonHelperMethodsDalc();
            PersonModel personSearchSample = new PersonModel();
            PersonViewModel personViewModel = new PersonViewModel();
            List<PersonViewModel> listPersonViewModel = new List<PersonViewModel>();

            Dictionary<string, int> genderDict = helper.GetGenderDictionary();
            Dictionary<string, int> maritalStatusDict = helper.GetMaritalStatusDictionary();
            string genderName = "";
            string maritalStatusName = "";

            // get a list of gender Names
            model.GenderTypes = genderDict.Keys.ToList();

            // get a list of marital status names
            model.MaritalStatusTypes = maritalStatusDict.Keys.ToList();

            personSearchSample = model.Person;

            if(model.Person.Gender != null) {
                personSearchSample.GenderID = genderDict[model.Person.Gender];
            }

            if (model.Person.MaritalStatus != null) {
                personSearchSample.MaritalStatusID = maritalStatusDict[model.Person.MaritalStatus];
            }

            
        
           
          
            List<PersonModel> searchExecutionResults = helper.ExecuteSearch(personSearchSample);

            // reverse dictionaries for faster O(1) lookup
            var reversedGenderDict = genderDict.ToDictionary(x => x.Value, x => x.Key);
            var reversedMaritalStatusDict = maritalStatusDict.ToDictionary(x => x.Value, x => x.Key);

            // get gender and marital status strings

            if(personSearchSample.GenderID != 0) {
                genderName = reversedGenderDict[personSearchSample.GenderID];
            }
            if(personSearchSample.MaritalStatusID != 0) {
                maritalStatusName = reversedMaritalStatusDict[personSearchSample.MaritalStatusID];
            }
            
            foreach(PersonModel person in searchExecutionResults) {
                PersonViewModel newViewModel = new PersonViewModel();
                newViewModel = person;
                newViewModel.Gender = reversedGenderDict[person.GenderID];
                newViewModel.MaritalStatus = reversedMaritalStatusDict[person.MaritalStatusID];
                listPersonViewModel.Add(newViewModel);
            }

            model.SearchResults = listPersonViewModel;

            return View(model);
        }

        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> files, ImportDataViewModel model){

            //ImportDataViewModel model = new ImportDataViewModel();
            model.PersonList = new List<PersonViewModel>();
            model.UploadStats = new UploadStatsViewModel();

            PersonHelperMethodsDalc personHelper = new PersonHelperMethodsDalc();

            // reverse dictionaries for quicker look up O(1)
            Dictionary<int, string> genderDictReversed = personHelper.GetGenderDictionary().ToDictionary(x => x.Value, x => x.Key);
            Dictionary<int, string> maritalStatusDictReversed = personHelper.GetMaritalStatusDictionary().ToDictionary(x => x.Value, x => x.Key);

            // TO DO: AT LEAST VALIDATE FILE SIGNATURES ...
            try {
                ExcelFileProcessor fileProc = new ExcelFileProcessor();
                List<PersonModel> table = null;

                foreach (IFormFile formFile in files) {
                    if (formFile.Length > 0) {
                        table = fileProc.ImportExcelFormFile(formFile);
                    }
                }

                
                foreach (var person in table) {

                    PersonViewModel viewPerson = new PersonViewModel();

                    viewPerson.FirstName = person.FirstName;
                    viewPerson.LastName = person.LastName;
                    viewPerson.Gender = genderDictReversed[person.GenderID];
                    viewPerson.DateOfBirth = person.DateOfBirth;
                    viewPerson.MaritalStatus = maritalStatusDictReversed[person.MaritalStatusID];
                    viewPerson.EmailAddress = person.EmailAddress;
                    viewPerson.StreetAddressLine1 = person.StreetAddressLine1;
                    viewPerson.StreetAddressLine2 = person.StreetAddressLine2;
                    viewPerson.PhoneNumber = person.PhoneNumber;
                    viewPerson.City = person.City;
                    viewPerson.State = person.State;
                    viewPerson.Zip = viewPerson.Zip;


                    model.PersonList.Add(viewPerson);
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