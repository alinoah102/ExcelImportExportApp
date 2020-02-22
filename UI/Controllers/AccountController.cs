using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataLibrary.BusinessLogicLayer.ExcelSheetProcessor;
using DataLibrary.DALC;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UI.Models;

namespace UI.Controllers {
    public class AccountController : Controller {
        public IActionResult AccountHome() {

            return View();
        }

        [HttpGet]
        public IActionResult RetrieveData() {

            PersonHelperMethodsDalc helperMethods = new PersonHelperMethodsDalc();
            SearchPersonViewModel model = new SearchPersonViewModel();

            Dictionary<int, string> genderDictReversed = helperMethods.GetGenderDictionary().ToDictionary(x => x.Value, x => x.Key);
            Dictionary<int, string> maritalStatusDictReversed = helperMethods.GetMaritalStatusDictionary().ToDictionary(x => x.Value, x => x.Key);

            List<PersonModel> personModelList = helperMethods.RetrieveData();
            List<PersonViewModel> personViewModelList = new List<PersonViewModel>();

            foreach(PersonModel person in personModelList) {

                PersonViewModel personViewModelObj = person;
                personViewModelObj.Gender = genderDictReversed[person.GenderID];
                personViewModelObj.MaritalStatus = maritalStatusDictReversed[person.MaritalStatusID];

                personViewModelList.Add(personViewModelObj);

            }

            model.SearchResults = personViewModelList;
            // get a list of gender Names
            model.GenderTypes = genderDictReversed.Values.ToList();

            // get a list of marital status names
            model.MaritalStatusTypes = maritalStatusDictReversed.Values.ToList();

            return View("SearchData", model);
        }

        [HttpPost]
        public IActionResult DeletePerson(string json) {

            var personId = JsonConvert.DeserializeObject<int>(json);
            PersonDalc personOperation = new PersonDalc();
            personOperation.PersonDelete(personId);

            return Json(new { success = true, responseText = $"Person Row With ID: {personId} Has Been Deleted Successfully" });
        }

        [HttpPost]
        public IActionResult ExportPerson(string json) {

           
            dynamic data = JObject.Parse(json);
        

            PersonHelperMethodsDalc helperMethods = new PersonHelperMethodsDalc();

            Dictionary<string, int> genderDict = helperMethods.GetGenderDictionary();
            Dictionary<string, int> maritalStatusDict = helperMethods.GetMaritalStatusDictionary();

            string gender = data.Gender;
            string maritalStatus = data.MaritalStatus;



            PersonModel person =  JsonConvert.DeserializeObject<PersonModel>(json);
            person.GenderID = genderDict[gender];
            person.MaritalStatusID = maritalStatusDict[maritalStatus];

            ExcelFileProcessor fileProc = new ExcelFileProcessor();

            List<PersonModel> personList = new List<PersonModel>();
            personList.Add(person);

            fileProc.ExportToExcel(personList, "Person.xlsx");

            return Json(new { success = true, responseText = "Person Has Been Exported Successfully" });

        }

        [HttpPost]
        public IActionResult ExportPersonList(string json) {


            dynamic data = JArray.Parse(json);

         
            PersonHelperMethodsDalc helperMethods = new PersonHelperMethodsDalc();

            Dictionary<string, int> genderDict = helperMethods.GetGenderDictionary();
            Dictionary<string, int> maritalStatusDict = helperMethods.GetMaritalStatusDictionary();


            List<PersonModel> personList = new List<PersonModel>();

            foreach (var p in data) {
                string gender = p.Gender;
                string maritalStatus = p.MaritalStatus;

                PersonModel person = new PersonModel();

                person.GenderID = genderDict[gender];
                person.MaritalStatusID = maritalStatusDict[maritalStatus];
                person.FirstName = p.FirstName;
                person.LastName = p.LastName;
                person.DateOfBirth = p.DateOfBirth;
                person.EmailAddress = p.EmailAddress;
                person.StreetAddressLine1 = p.StreetAddressLine1;
                person.StreetAddressLine2 = p.StreetAddressLine2;
                person.City = p.City;
                person.Zip = p.Zip;
                person.PhoneNumber = p.PhoneNumber;
                person.State = p.State;

                personList.Add(person);
            }

            ExcelFileProcessor fileProc = new ExcelFileProcessor();

            fileProc.ExportToExcel(personList, "Data.xlsx");

            return Json(new { success = true, responseText = "Data Has Been Exported Successfully" });

        }

        [HttpPost]
    
        public IActionResult UpdatePerson(string json) {

            PersonViewModel personViewModelNew = JsonConvert.DeserializeObject<PersonViewModel>(json);

            PersonDalc personOperation = new PersonDalc();
            PersonHelperMethodsDalc helperMethods = new PersonHelperMethodsDalc();

            Dictionary<string, int> genderDict = helperMethods.GetGenderDictionary();
            Dictionary<string, int> maritalStatusDict = helperMethods.GetMaritalStatusDictionary();

            PersonModel person = new PersonModel();
            person = personViewModelNew;
            person.GenderID = genderDict[personViewModelNew.Gender];
            person.MaritalStatusID = maritalStatusDict[personViewModelNew.MaritalStatus];

            personOperation.PersonUpdate(person);

            return Json(new { success = true, responseText = $"Person ID:{person.PersonID} Has Been Updated Successfully" });
        }

        [HttpPost]
        public IActionResult AddPerson(string json) {

            PersonViewModel personViewModelNew = JsonConvert.DeserializeObject<PersonViewModel>(json);

            PersonDalc personOperation = new PersonDalc();
            PersonHelperMethodsDalc helperMethods = new PersonHelperMethodsDalc();

            Dictionary<string, int> genderDict = helperMethods.GetGenderDictionary();
            Dictionary<string, int> maritalStatusDict = helperMethods.GetMaritalStatusDictionary();

            PersonModel person = new PersonModel();
            person = personViewModelNew;
            person.GenderID = genderDict[personViewModelNew.Gender];
            person.MaritalStatusID = maritalStatusDict[personViewModelNew.MaritalStatus];

            personOperation.PersonInsert(person);

            return Json(new { success = true, responseText = $" {person.FirstName} {person.LastName} Of {person.City} Has Been Added Successfully" });
        }



        [HttpGet]
        public IActionResult ImportData(ImportDataViewModel model) {

            model.PersonList = new List<PersonViewModel>();
            model.UploadStats = new UploadStatsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult SearchData() {

            SearchPersonViewModel model = new SearchPersonViewModel();
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

            if (model.Person.Gender != null) {
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

            if (personSearchSample.GenderID != 0) {
                genderName = reversedGenderDict[personSearchSample.GenderID];
            }
            if (personSearchSample.MaritalStatusID != 0) {
                maritalStatusName = reversedMaritalStatusDict[personSearchSample.MaritalStatusID];
            }

            int count = 0;
            foreach (PersonModel person in searchExecutionResults) {

                // limit how many rows we get for now, or we can implement pages
                count++;
                if (count == 25) {
                    break;
                }

                PersonViewModel newViewModel = new PersonViewModel();
                newViewModel = person;
                newViewModel.Gender = reversedGenderDict[person.GenderID];
                newViewModel.MaritalStatus = reversedMaritalStatusDict[person.MaritalStatusID];
                listPersonViewModel.Add(newViewModel);
            }

            model.SearchResults = listPersonViewModel;
            model.NumberOfRecordsRetrieved = listPersonViewModel.Count;

            return View(model);
        }

        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> files, ImportDataViewModel model) {

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

                // break after 100.. silly way to do this. just use a for loop..

                int count = 0;
                foreach (var person in table) {

                    count++;
                    if (count == 25) {
                        break;
                    }


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
                    viewPerson.Zip = person.Zip;


                    model.PersonList.Add(viewPerson);
                }

                model.UploadStats.NumberOfRecords = table.Count();
                model.UploadStats.FileName = files[0].FileName;

            }
            catch (Exception e) {
                // TO DO
            }

            return View("ImportData", model);
        }
    }
}

