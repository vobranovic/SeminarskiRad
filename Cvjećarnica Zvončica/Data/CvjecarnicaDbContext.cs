using Cvjećarnica_Zvončica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Data
{
    public class CvjecarnicaDbContext : DbContext
    {

        public CvjecarnicaDbContext(DbContextOptions<CvjecarnicaDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cvijet> Cvijet { get; set; }
        public DbSet<Buket> Buket { get; set; }


        //public List<Cvijet> GetAll()
        //{
        //    return Cvijet.ToList();
        //}

        //public void UnesiNoviCvijet(Cvijet cvijet)
        //{
        //    Cvijet.Add(cvijet);
        //}
    }
}
