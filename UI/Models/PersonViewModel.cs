using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models {
    public class PersonViewModel {
      
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
   
        public int MaritalStatus { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
