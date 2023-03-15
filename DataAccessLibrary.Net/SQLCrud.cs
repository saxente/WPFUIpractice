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
        public FullPersonModel GetAddressesByPersonId(int id)

        {

            string sql = "select Id, FirstName, LastName, EmailAddress, PhoneNumber, IsActive from dbo.Person where Id = @Id";



            FullPersonModel output = new FullPersonModel();

            output.BasicPersonInfo = db.LoadData<BasicPersonModel, dynamic>(sql, new { Id = id }, _connectionString).FirstOrDefault();



            if (output.BasicPersonInfo == null)

            {

                return null;

            }



            sql = @"select a.*

                    from dbo.Address a

                    inner join dbo.PersonAddress pa on pa.AddressId = a.Id

                    where PersonId = @Id;";



            output.Addresses = db.LoadData<AddressModel, dynamic>(sql, new { Id = id }, _connectionString);



            return output;
        }

     }
}
