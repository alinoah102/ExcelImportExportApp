using DataLibrary.DataAccessLayer;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace DataLibrary.BusinessLogicLayer.PersonUtilities {
    public static class PersonDataGet {
        
        public static List<PersonModel> PersonDataGetAll() {
            List<PersonModel> listOfPersonTableData = new List<PersonModel>();
            using (IDbConnection db = new SqlConnection(DatabaseHelper.ConnectionStringGet())){
                try {
                    listOfPersonTableData = db.Query<PersonModel>("Select * from dbo.Person").ToList(); // change this
                }catch(SqlException e) {
                    // TODO
                }
            }
            return listOfPersonTableData;
        } 

    }
}
