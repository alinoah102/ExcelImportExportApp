using DataLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using Dapper;
using System.Linq;
using DataLibrary.Models;
using System.Reflection;
using Newtonsoft.Json;

namespace DataLibrary.DALC {
    public class PersonHelperMethodsDalc {

        public List<PersonModel> ExecuteSearch(PersonModel data) {

            // serialize object to json to check for null values before db call
            var json = JsonConvert.SerializeObject(data);
            Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var cleanData = dictionary.Where(kvp => kvp.Value != null && kvp.Value != "0");
           

            string selectString = "SELECT ";
            string whereString = "WHERE ";


            var last = cleanData.LastOrDefault();
            

            foreach (var result in cleanData) {

                if (!result.Equals(last)) {

                    switch (result.Key) {
                        // special cases for integers...
                        case "GenderID":
                            whereString += ($"[GenderID] = {result.Value} AND ");
                            break;
                        case "MaritalStatusID":
                            whereString += ($"[MaritalStatusID] = {result.Value} AND ");
                            break;
                        
                        default:
                            whereString += ($"[{result.Key.ToString()}] = '{result.Value.ToString()}' AND ");
                            break;
                    }
                    
                } else {

                    switch (result.Key) {
                        // special cases
                        case "Gender":
                            whereString += ($"[GenderID] = {result.Value} AND ");
                            break;
                        case "MaritalStatus":
                            whereString += ($"[MaritalStatusID] = {result.Value} AND ");
                            break;

                        default:
                            whereString += ($"[{result.Key.ToString()}] = '{result.Value.ToString()}'");
                            break;
                    }
                }
            }

            string sqlCommand = $@"{selectString} 
                                 [PersonID]
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
                                FROM [dbo].[Person] {whereString}";

            try {

                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());
                List<PersonModel> result = db.Query<PersonModel>(sqlCommand).ToList();

                return result;
            }
            catch (Exception e) {
                // TO DO
            }
                
            return null;

        }

        // This method will reuturn key/value pairs of reverse db layout for performance purposes GenderName/GenderID O(1)
        public Dictionary<string, int> GetGenderDictionary() {
            try {

            IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());

            Dictionary<string, int> genderDict = db.Query<GenderModel>("Select GenderID, GenderName FROM [dbo].[Gender]").ToDictionary(x => x.GenderName, x => x.GenderID);

            if(genderDict != null) {
                    return genderDict;
            }

            }catch(Exception e) {
                // TO DO
            }

            return null;
        }


        // This method will reuturn key/value pairs of reverse db layout for performance purposes MaritalStatusName/MaritalStatusID
        public Dictionary<string, int> GetMaritalStatusDictionary() {
            try {

                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());

                Dictionary<string, int> maritalStatusDict = db.Query<MaritalStatusModel>("Select MaritalStatusID, MaritalStatusName FROM [dbo].[MaritalStatus]").ToDictionary(x => x.MaritalStatusName, x => x.MaritalStatusID);

                if (maritalStatusDict != null) {
                    return maritalStatusDict;
                }

            }
            catch (Exception e) {
                // TO DO
            }

            return null;
        }


       
         public List<PersonModel> RetrieveData(int numOfRows = 25) {
            try {

                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());

                List<PersonModel> results = db.Query<PersonModel>($@"
                        SELECT TOP {numOfRows} 
                              [PersonID]
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
                    ").ToList();

                if (results != null) {
                    return results;
                }

            }
            catch (Exception e) {
                // TO DO
            }

            return null;
        }





    }
}