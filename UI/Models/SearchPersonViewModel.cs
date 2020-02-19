using DataLibrary.DALC;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.BusinessLogicLayer;

namespace UI.Models {
    public class SearchPersonViewModel {

       public PersonViewModel Person { get; set; }

       public PersonViewModel UpdatePerson { get; set; }

        public List<string> GenderTypes {
            get; set;
        }

        public List<string> MaritalStatusTypes {
            get; set;
        }

        public List<PersonViewModel> SearchResults { get; set; }

        public List<string> States {
            get {
                return StateArray.Abbreviations().ToList();
            }
        }

        public int NumberOfRecordsRetrieved { get; set; }

    }
}
