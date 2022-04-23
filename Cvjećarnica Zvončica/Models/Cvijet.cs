﻿using Cvjećarnica_Zvončica.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Models
{
    public class Cvijet
    {
        public int Id { get; set; }

        [Required]
        public NazivCvijeta Naziv { get; set; }

        [Required]
        public BojaCvijeta Boja { get; set; }

        public DateTime Datum { get; set; }

        public string ImgUrl { get; set; }

        [Required]
        public decimal Cijena { get; set; }

    }

}
