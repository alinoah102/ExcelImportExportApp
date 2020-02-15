using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace UI.Models {
    public class PersonViewModel {
      
        public int PersonID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Marital Status")]
        public string MaritalStatus { get; set; }

        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Address Line 1")]
        public string StreetAddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string StreetAddressLine2 { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip")]
        public string Zip { get; set; }



        public static implicit operator PersonViewModel(PersonModel person) {
            return new PersonViewModel {
                PersonID = person.ID,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                MaritalStatus = person.MaritalStatus,
                EmailAddress = person.EmailAddress,
                StreetAddressLine1 = person.StreetAddressLine1,
                StreetAddressLine2 = person.StreetAddressLine2,
                PhoneNumber = person.PhoneNumber,
                City = person.City,
                State = person.State,
                Zip = person.Zip
            };
        }

        public static implicit operator PersonModel(PersonViewModel vm) {
            return new PersonModel {
                ID = vm.PersonID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Gender = vm.Gender,
                DateOfBirth = vm.DateOfBirth,
                MaritalStatus = vm.MaritalStatus,
                EmailAddress = vm.EmailAddress,
                StreetAddressLine1 = vm.StreetAddressLine1,
                StreetAddressLine2 = vm.StreetAddressLine2,
                PhoneNumber = vm.PhoneNumber,
                City = vm.City,
                State = vm.State,
                Zip = vm.Zip
            };
        }
    }

    
}
