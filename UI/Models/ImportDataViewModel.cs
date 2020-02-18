using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models {
    public class ImportDataViewModel {

        public List<PersonViewModel> PersonList { get; set; }

        public UploadStatsViewModel UploadStats { get; set; }

        public bool ViewData { get; set; }


    }
}
