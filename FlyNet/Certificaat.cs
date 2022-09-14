using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Personeel
{
    public class Certificaat
    {
        public string CertificaatAfkorting { get; set; }
        public string CertificaatOmschrijving { get; set; }
        public Certificaat() { }
        public Certificaat(string certificaatAfkorting, string certificaatOmschrijving)
        {
            CertificaatAfkorting = certificaatAfkorting;
            CertificaatOmschrijving = certificaatOmschrijving;
        }
        public override string ToString()
        {
            return $"{CertificaatAfkorting}, {CertificaatOmschrijving}";
        }
    }
    
}
