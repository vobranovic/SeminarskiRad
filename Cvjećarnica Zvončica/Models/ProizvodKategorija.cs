using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class ProizvodKategorija
    {
        public int Id { get; set; }
        public int KategorijaId { get; set; }
        public int ProizvodId { get; set; }

        [NotMapped]
        public string NazivProizvoda { get; set; }
        [NotMapped]
        public string NazivKategorije { get; set; }
    }
}
