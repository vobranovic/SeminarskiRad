using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class Proizvod
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv je obavezan.")]
        [StringLength(200, MinimumLength = 2)]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Količina je obavezna.")]
        [Range(0,int.MaxValue)]
        public int Kolicina { get; set; }

        [Required(ErrorMessage = "Cijena je obavezna.")]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Cijena { get; set; }

        [Required(ErrorMessage = "Opis je obavezan.")]
        [StringLength(2000, MinimumLength = 5)]
        public string Opis { get; set; }

        [ForeignKey("ProizvodId")]
        public List<Stavka> Stavke { get; set; }

        [ForeignKey("ProizvodId")]
        public List<ProizvodKategorija> ProizvodKategorija { get; set; }


    }
}
