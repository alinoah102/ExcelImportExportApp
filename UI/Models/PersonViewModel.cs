using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models {
    public class PersonViewModel {
      
        public int PersonID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
   
        public string MaritalStatus { get; set; }

        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
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
