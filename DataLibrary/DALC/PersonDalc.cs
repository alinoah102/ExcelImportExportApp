using DataLibrary.Models;
using DataLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Transactions;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Bibliography;
using System.Data;

namespace DataLibrary.DALC {


    public class PersonDalc {
        public void PersonInsert(PersonModel model) {

            try {

                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());
                using (TransactionScope scope = new TransactionScope()) {

                    var result = db.Execute($@"
                          INSERT INTO [dbo].[Person]

                                   (FirstName
                                   ,LastName
                                   ,GenderID
                                   ,DateOfBirth
                                   ,MaritalStatusID
                                   ,EmailAddress
                                   ,StreetAddressLine1
                                   ,StreetAddressLine2
                                   ,PhoneNumber
                                   ,City
                                   ,State
                                   ,Zip)
                             VALUES
                                   ('{model.FirstName}'
                                   ,'{model.LastName}'
                                   ,1
                                   ,'{model.DateOfBirth}'
                                   ,1
                                   ,'{model.EmailAddress}'
                                   ,'{model.StreetAddressLine1}'
                                   ,'{model.StreetAddressLine2}'
                                   ,'{model.PhoneNumber}'
                                   ,'{model.City}'
                                   ,'{model.State}'
                                   ,'{model.Zip}')

                    ");
                    scope.Complete();
                }

            }
            catch (TransactionAbortedException ex) {
                // TO DO
            }

        }
    }

}