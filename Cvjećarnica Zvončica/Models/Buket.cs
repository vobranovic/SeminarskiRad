using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class Buket
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
        
        public DateTime Datum { get; set; }

        [Required]
        public List<Cvijet> Cvijece { get; set; }

        public string ImgUrl { get; set; }

        [Required]
        public decimal Cijena { get; set; }

    }
}
