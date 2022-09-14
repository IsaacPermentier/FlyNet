using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Personeel
{
    public class CockpitPersoneelslid : VliegendPersoneelslid
    {
        public int Vlieguren { get; set; }
        private Graad graadValue;
        public override Graad Graad
        {
            get => graadValue;
            set
            {
               if (value != Graad.Steward && value != Graad.Purser)
                        graadValue = value;
               else
                    throw new GraadException($"Verkeerde graad ({value}), deze behoort niet tot de mogelijke graden van de cockpitcrew" +
                        $"(Captain, SeniorFlightOfficer, SecondOfficer of JuniorFlightOfficer)");                
            }
        }
        public class GraadException : Exception
        {

            public GraadException(string message) : base(message)
            {
            }
        }
        public CockpitPersoneelslid(int personeelslidID, string naam, decimal basisKostprijsPerDag, Graad graad, List<Certificaat> certificaten, int vlieguren)
            : base(personeelslidID, naam, basisKostprijsPerDag, graad, certificaten)
        {
            Vlieguren = vlieguren;
        }
        public override string ToString()
        {
            return @$"Vlieguren: {Vlieguren}
Totale kostprijs per dag: {BerekenTotaleKostprijsperDag()} euro";
        }

        public override decimal BerekenTotaleKostprijsperDag()
        {
            decimal totaleKostprijsPerDag = 0m;
            if (Graad == Graad.Captain)
                totaleKostprijsPerDag = BasisKostprijsPerDag * 1.30m;
            if (Graad == Graad.SeniorFilghtOfficer)
                totaleKostprijsPerDag = BasisKostprijsPerDag * 1.20m;
            if (Graad == Graad.SecondOfficer)
                totaleKostprijsPerDag = BasisKostprijsPerDag * 1.10m;
            if (Graad == Graad.JuniorFlightOfficer)
                totaleKostprijsPerDag = BasisKostprijsPerDag;
            foreach (var certificaat in Certificaten)
            {
                if (certificaat.CertificaatAfkorting.ToString() == "CPL")
                    totaleKostprijsPerDag += 50m;
            }
            return totaleKostprijsPerDag;
        }
    }
}
