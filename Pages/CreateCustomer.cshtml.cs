using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OltcoApp.Models;

namespace OltcoApp.Pages
{
    public class CreateCustomerModel : PageModel
    {
        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();

        [BindProperty]
        public Customer customer { get; set; }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            objcustomer.AddCustomer(customer);

            return RedirectToPage("./CustomerIndex");
        }
    }
}
