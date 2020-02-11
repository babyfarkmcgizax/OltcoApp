using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OltcoApp.Models;

namespace OltcoApp.Pages
{
    public class DeleteCustomerModel : PageModel
    {
        CustomerDataAccessLayer objcustomer = new CustomerDataAccessLayer();

        public Customer customer { get; set; }

        public ActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            customer = objcustomer.GetCustomerData(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            objcustomer.DeleteCustomer(id);

            return RedirectToPage("./CustomerIndex");
        }
    }
}
