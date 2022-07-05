using System.ComponentModel.DataAnnotations;

namespace Cvjećarnica_Zvončica.Models
{
    public class KorisnikViewModel
    {
        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        public string Adresa { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatedPassword { get; set; }
    }
}
