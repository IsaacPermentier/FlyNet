using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Personeel
{
    public class CabinePersoneelslid : VliegendPersoneelslid
    {
        public string Werkpositie { get; set; }
        private Graad graadValue;
        public override Graad Graad
        {
            get => graadValue;
            set
            {
                if (value == Graad.Steward || value == Graad.Purser)
                    graadValue = value;
                else
                    throw new GraadException($"Verkeerde graad ({value}), deze behoort niet tot de mogelijke graden van de cabinecrew" +
                        $"(Steward of Purser)");
            }
        }
        public class GraadException : Exception
        {

            public GraadException(string message) : base(message)
            {
            }
        }
        public CabinePersoneelslid(int personeelslidID, string naam, decimal basisKostprijsPerDag, Graad graad, List<Certificaat> certificaten, string werkpositie)
            : base(personeelslidID, naam, basisKostprijsPerDag, graad, certificaten)
        {
            Werkpositie = werkpositie;
        }
        
        public override decimal BerekenTotaleKostprijsperDag()
        {
            decimal totaleKostprijsPerDag = 0m;
            if (Graad == Graad.Purser)
                totaleKostprijsPerDag = BasisKostprijsPerDag * 1.20m;            
            if (Graad == Graad.Steward)
                totaleKostprijsPerDag = BasisKostprijsPerDag;
            foreach (var certificaat in Certificaten)
            {
                if (certificaat.CertificaatAfkorting.ToString() == "EHBO")
                    totaleKostprijsPerDag += 5m;
            }
            return totaleKostprijsPerDag;
        }
        public override string ToString()
        {
            return @$"Werkpositie: {Werkpositie}
Totale kostprijs per dag: {BerekenTotaleKostprijsperDag()} euro";
        }
    }
}
