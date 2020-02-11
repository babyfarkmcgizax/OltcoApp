using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OltcoApp.Models;

namespace OltcoApp.Pages
{
    public class CustomerIndexModel : PageModel
    {
        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();
        public List<Customer> customer { get; set; }

        public void OnGet()
        {
            customer = objcustomer.GetAllCustomers().ToList();
        }
    }
}
