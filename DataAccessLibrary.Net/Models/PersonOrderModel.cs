using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Net.Models
{
    public class PersonOrderModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int OrderId { get; set; }
    }
}
