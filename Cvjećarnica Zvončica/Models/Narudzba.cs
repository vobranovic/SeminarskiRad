using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class Narudzba
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Datum je obavezan!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Ukupan iznos je obavezan.")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Ukupno { get; set; }

        [Required(ErrorMessage = "Ime kupca je obavezno.")]
        [Display(Name = "Ime Kupca")]
        [StringLength(100)]
        public string ImeKupca { get; set; }

        [Required(ErrorMessage = "Prezime kupca je obavezno.")]
        [Display(Name = "Prezime Kupca")]
        [StringLength(100)]
        public string PrezimeKupca { get; set; }

        [Required(ErrorMessage = "Email kupca je obavezan.")]
        [Display(Name = "E-Mail Kupca")]
        [StringLength(100)]
        public string EmailKupca { get; set; }

        [Required(ErrorMessage = "Telefon kupca je obavezan.")]
        [Display(Name = "Telefon Kupca")]
        [StringLength(50)]
        public string TelefonKupca { get; set; }

        [Required(ErrorMessage = "Adresa kupca je obavezna.")]
        [Display(Name = "Adresa Kupca")]
        [StringLength(150)]
        public string AdresaKupca { get; set; }

        [Required(ErrorMessage = "Grad kupca je obavezan.")]
        [Display(Name = "Grad Kupca")]
        [StringLength(100)]
        public string GradKupca { get; set; }

        [Required(ErrorMessage = "Drzava kupca je obavezna.")]
        [Display(Name = "Drzava Kupca")]
        [StringLength(75)]
        public string DrzavaKupca { get; set; }

        [Required(ErrorMessage = "Postanski Broj kupca je obavezan.")]
        [Display(Name = "Postanski Broj Kupca")]
        [StringLength(25)]
        public string PostanskiBrojKupca { get; set; }

        [ForeignKey("StavkaId")]
        public List<Stavka> Stavke { get; set; }

        public string UserId { get; set; }

    }
}
