using Npoi.Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataLibrary.Models {
    public class PersonModel {
        [Ignore]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }

        [Ignore]
        public int GenderID { get; set; }
        [Ignore]
        public int MaritalStatusID { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
