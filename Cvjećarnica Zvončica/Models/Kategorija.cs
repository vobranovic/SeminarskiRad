using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class Kategorija
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string Naziv { get; set; }

        [ForeignKey("KategorijaId")]
        public List<ProizvodKategorija> ProizvodKategorija { get; set; }

    }
}
