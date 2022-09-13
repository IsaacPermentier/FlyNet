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
        public Graad Graad
        {
            get => graadValue;
            set
            {
                if (value == Graad.Steward || value == Graad.Purser)
                    graadValue = value;
                else
                    throw new Exception($"Verkeerde graad ({value}), deze behoort niet tot de mogelijke graden van de cabinecrew" +
                        $"(Steward of Purser)");
            }
        }
        public override decimal BerekenTotaleKostprijsperDag()
        {
            decimal totaleKostprijsPerDag = BasisKostprijsPerDag;
            if (Graad == Graad.Purser)
                totaleKostprijsPerDag *= 1.2m;            
            else
                totaleKostprijsPerDag = BasisKostprijsPerDag;
            return totaleKostprijsPerDag;
        }
        public override string ToString()
        {
            string cabinePersoneelslid = $"{base.ToString()} - (basiskostprijs per dag: {BasisKostprijsPerDag} euro";
            return cabinePersoneelslid.ToString();
        }
    }
}
