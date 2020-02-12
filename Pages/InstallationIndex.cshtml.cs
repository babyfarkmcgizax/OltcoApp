using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OltcoApp.Models;

namespace OltcoApp.Pages
{
    public class InstallationIndexModel : PageModel
    {
        InstallationDataAccessLayer objinstallation = new InstallationDataAccessLayer();
        public List<Installation> installation { get; set; }

        public void OnGet()
        {
            installation = objinstallation.GetAllInstallations().ToList();
        }
    }
}
