using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OltcoApp.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string customer_name { get; set; }
        public string customer_address { get; set; }
        public string phone_number { get; set; }
        public string postcode { get; set; }
        public string email { get; set; }
    }
}
