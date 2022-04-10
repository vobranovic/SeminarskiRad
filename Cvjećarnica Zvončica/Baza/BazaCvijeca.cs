using Cvjećarnica_Zvončica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvjećarnica_Zvončica.Baza
{
    public class BazaCvijeca
    {
        private static List<Cvijet> _cvijece;

        public BazaCvijeca()
        {
            if (_cvijece == null)
            {
                _cvijece = new List<Cvijet>()
                {
                    new Cvijet() { CvijetId = 0,  Naziv = Naziv.Ruža, Boja = Boja.Bijela, Cijena = 20.00D , Zaprimljeno = new DateTime(2022,4,3) },
                    new Cvijet() { CvijetId = 1, Naziv = Naziv.Tulipan, Boja = Boja.Crvena, Cijena = 5.00D , Zaprimljeno = new DateTime(2022,4,2) },
                    new Cvijet() { CvijetId = 2, Naziv = Naziv.Orhideja, Boja = Boja.Narančasta, Cijena = 4.00D , Zaprimljeno = new DateTime(2022,4,1) },
                    new Cvijet() { CvijetId = 3, Naziv = Naziv.Jaglac, Boja = Boja.Žuta, Cijena = 10.00D , Zaprimljeno = new DateTime(2022,4,5) },
                    new Cvijet() { CvijetId = 4, Naziv = Naziv.Kala, Boja = Boja.Plava, Cijena = 6.00D , Zaprimljeno = new DateTime(2022,4,2) },
                    new Cvijet() { CvijetId = 5, Naziv = Naziv.Kala, Boja = Boja.Plava, Cijena = 6.00D , Zaprimljeno = new DateTime(2022,4,2) },
                    new Cvijet() { CvijetId = 6, Naziv = Naziv.Orhideja, Boja = Boja.Plava, Cijena = 6.00D , Zaprimljeno = new DateTime(2022,4,2) }
                };
            }
        }

        public List<Cvijet> PopisSvogCvijeca()
        {
            return _cvijece;
        }

        public void DodajNoviCvijet(Cvijet cvijet)
        {
            _cvijece.Add(cvijet);
        }

        public List<Cvijet> Stanje()
        {
            var cvijece = _cvijece.GroupBy(c => c.Naziv)
            return _cvijece;
        }
    }
}
