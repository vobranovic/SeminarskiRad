using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }

    }
}
