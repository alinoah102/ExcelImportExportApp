using DataLibrary.DALC;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models {
    public class SearchDataModel {

       public PersonViewModel Person { get; set; }

        public List<string> GenderTypes {
            get; set;
        }

        public List<string> MaritalStatusTypes {
            get; set;
        }


    }
}
