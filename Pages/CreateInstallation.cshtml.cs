using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OltcoApp.Models;

namespace OltcoApp.Pages
{
    public class CreateInstallationModel : PageModel
    {
 
        InstallationDataAccessLayer objinstallation = new InstallationDataAccessLayer();

        [BindProperty]
        public Installation installation { get; set; }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            objinstallation.AddInstallation(installation);

            return RedirectToPage("./InstallationIndex");
        }
    }
}

