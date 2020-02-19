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
using System.Linq;


namespace DataLibrary.DALC {


    public class PersonDalc {





        public List<PersonModel> GetPersonByID(string id) {
            try {
                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());
                List<PersonModel> result = db.Query<PersonModel>($@"
                      SELECT [PersonID]
                            ,[FirstName]
                            ,[LastName]
                            ,[GenderID]
                            ,[DateOfBirth]
                            ,[MaritalStatusID]
                            ,[EmailAddress]
                            ,[StreetAddressLine1]
                            ,[StreetAddressLine2]
                            ,[PhoneNumber]
                            ,[City]
                            ,[State]
                            ,[Zip]
                        FROM [dbo].[Person]
                        WHERE [id] = {id}

                ").ToList();

                return result;

            }
            catch(SqlException e) {
                switch (e.Number) {
                    
                }
                // TO DO
            }

            return null;

        }

        public void PersonDelete(int personId) {
            try {
                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());
                using (TransactionScope scope = new TransactionScope()) {
                    var result = db.Execute($@"
                          DELETE FROM [dbo].[Person]
                          WHERE  PersonID = {personId}
                          
                    ");
                    scope.Complete();
                }
            }
            catch (TransactionAbortedException ex) {
                // TO DO...
            }

        }


        public void PersonUpdate(PersonModel model) {
            try {
                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());
                using (TransactionScope scope = new TransactionScope()) {
                    var result = db.Execute($@"
                          UPDATE [dbo].[Person]
                                   
                          SET       FirstName = '{model.FirstName}'
                                   ,LastName = '{model.LastName}'
                                   ,GenderID = {model.GenderID}
                                   ,DateOfBirth = '{model.DateOfBirth}'
                                   ,MaritalStatusID = {model.MaritalStatusID}
                                   ,EmailAddress = '{model.EmailAddress}'
                                   ,StreetAddressLine1 = '{model.StreetAddressLine1}'
                                   ,StreetAddressLine2 = '{model.StreetAddressLine2}'
                                   ,PhoneNumber = '{model.PhoneNumber}'
                                   ,City = '{model.City}'
                                   ,State = '{model.State}'
                                   ,Zip = '{model.Zip}'

                          WHERE     PersonID = {model.PersonID}
                          
                    ");
                    scope.Complete();
                }

            }
            catch (TransactionAbortedException ex) {
                // TO DO...
            }

        }
    

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
                                   ,{model.GenderID}
                                   ,'{model.DateOfBirth}'
                                   ,{model.MaritalStatusID}
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
                // TO DO...
            }

        }
    }

}