using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Net.Models
{
    public class OrderModel
    {  
        public int Id { get; set; }
        public string OrderRef { get; set; }
        public string ProductName { get; set; }
        public SelectStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}
