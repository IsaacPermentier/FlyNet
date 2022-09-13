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
        public Graad Graad
        {
            get => graadValue;
            set
            {
               if (value != Graad.Steward && value != Graad.Purser)
                        graadValue = value;
               else
                    throw new Exception($"Verkeerde graad ({value}), deze behoort niet tot de mogelijke graden van de cockpitcrew" +
                        $"(Captain, SeniorFlightOfficer, SecondOfficer of JuniorFlightOfficer)");                
            }
        }        
        public override string ToString()
        {
            string cockpitPersoneelslid = $"{base.ToString()} - (basiskostprijs per dag: {BasisKostprijsPerDag} euro";
            return cockpitPersoneelslid.ToString();
        }

        public override decimal BerekenTotaleKostprijsperDag()
        {
            decimal totaleKostprijsPerDag = BasisKostprijsPerDag;
            if (Graad == Graad.Captain)
                totaleKostprijsPerDag *= 1.3m;
            else if (Graad == Graad.SeniorFilghtOfficer)
                totaleKostprijsPerDag *= 1.2m;
            else if (Graad == Graad.SecondOfficer)
                totaleKostprijsPerDag *= 1.1m;
            else
                totaleKostprijsPerDag = BasisKostprijsPerDag;
            return totaleKostprijsPerDag;
        }
    }
}
