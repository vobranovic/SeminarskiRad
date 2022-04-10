using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class Cvijet
    {
        [Required(ErrorMessage = "Cvijet Id je obavezan.")]
        public int? CvijetId { get; set; }

        [Required(ErrorMessage = "Odaberite naziv cvijeta.")]
        public Naziv Naziv { get; set; }

        [Required(ErrorMessage = "Odaberite boju cvijeta.")]
        public Boja Boja { get; set; }

        [Required(ErrorMessage = "Cijena cvijeta je obavezna.")]
        [Range(0,double.MaxValue, ErrorMessage = "Cijena mora biti veća od nule.")]
        public double? Cijena { get; set; }

        //[Required(ErrorMessage = "Kolicina na stanju je obavezna.")]
        //[Range(0, int.MaxValue, ErrorMessage = "Kolicina mora biti veća od nule.")]
        //[DisplayName("Količina Na Stanju")]
        //public int? KolicinaNaStanju { get; set; }

        public DateTime Zaprimljeno { get; set; }
    }
}
