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
        public override string ToString()
        {
            string certificaat = $"{CertificaatAfkorting}, {CertificaatOmschrijving}";
            return certificaat.ToString();
        }
    }
    
}
