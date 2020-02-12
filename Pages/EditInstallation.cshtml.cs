using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OltcoApp.Models;

namespace OltcoApp.Pages
{
    public class EditInstallationModel : PageModel
    {
        InstallationDataAccessLayer objinstallation = new InstallationDataAccessLayer();

        [BindProperty]
        public Installation installation { get; set; }

        public ActionResult OnGet(int? installation_id)
        {
            if (installation_id == null)
            {
                return NotFound();
            }
            installation = objinstallation.GetInstallationData(installation_id);

            if (installation == null)
            {
                return NotFound();
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            objinstallation.UpdateInstallation(installation);

            return RedirectToPage("./InstallationIndex");
        }
    }
}
