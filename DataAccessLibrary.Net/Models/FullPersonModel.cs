using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Net.Models
{
    public class FullPersonModel
    {
        public BasicPersonModel BasicPersonInfo { get; set; }

        public List<AddressModel> Addresses { get; set; }
    }
}
