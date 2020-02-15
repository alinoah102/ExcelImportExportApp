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



namespace DataLibrary.DALC {
    public class PersonHelperMethodsDalc {

        // This method will reuturn key/value pairs of reverse db layout for performance purposes GenderName/GenderID
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

        // This method will reuturn a lsit of genders
        public List<string> GetGenderTypes() {
            try {

                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());

                List<string> genderTypes = db.Query<string>("Select GenderName FROM [dbo].[Gender]").ToList();

                if (genderTypes != null) {
                    return genderTypes;
                }

            }
            catch (Exception e) {
                // TO DO
            }

            return null;
        }

        // This method will a list of marital status types
        public List<string> GetMaritalStatusTypes() {
            try {

                IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet());

                List<string> maritalStatusTypes = db.Query<string>("Select [MaritalStatusName] FROM [dbo].[MaritalStatus]").ToList();

                if (maritalStatusTypes != null) {
                    return maritalStatusTypes;
                }

            }
            catch (Exception e) {
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



    }
}