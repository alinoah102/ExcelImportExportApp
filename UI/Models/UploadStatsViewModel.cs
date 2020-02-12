using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models {
    public class UploadStatsViewModel {
        public int NumberOfRecords { get; set; }
        public string UploadDateTime { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FileName { get; set; }

    }
}
