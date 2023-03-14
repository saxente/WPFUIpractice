using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Net.Models
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        private SQLDataAccess db = new SQLDataAccess();
        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BasicPersonModel> GetAllPersons()
        {
            string sql = "select Id, FirstName, LastName, EmailAddress, PhoneNumber, IsActive from dbo.Person";

            return db.LoadData<BasicPersonModel, dynamic>(sql, new { }, _connectionString);

        }


    }
}
