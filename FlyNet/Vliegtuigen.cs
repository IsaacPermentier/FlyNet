using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Vloot
{
    public class Vliegtuigen : IKost
    {
        public decimal BasisKostprijsPerDag { get; set; }
        private string typeValue;
        public string Type 
        { 
            get => typeValue;
            set
            {
                if (value != null)
                    typeValue = value;
                else
                    throw new Exception("Type is verplicht");
            } 
        }
        private int kruissnelheidValue;
        public int Kruissnelheid
        {
            get => kruissnelheidValue;
            set
            {
                if (value >= 0)
                    kruissnelheidValue = value;
                else
                    throw new Exception("Kruissnelheid is verplicht");
            }
        }
        private int vliegbereikValue;
        public int Vliegbereik
        {
            get => vliegbereikValue;
            set
            {
                if (value >= 0)
                    vliegbereikValue = value;
                else
                    throw new Exception("Vliegbereik is verplicht");
            }
        }
        public decimal BerekenTotaleKostprijsperDag()
        {
            return BasisKostprijsPerDag;
        }
    }
}
