using Cvjećarnica_Zvončica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cvjećarnica_Zvončica.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }
        public DbSet<Stavka> Stavka { get; set; }
        public DbSet<ProizvodKategorija> ProizvodKategorija { get; set; }

    }
}
