using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyNet.Vloot;
using FlyNet.Personeel;

namespace FlyNet
{
    public class Vluchten
    {
        public int VluchtID { get; set; }
        public string Bestemming { get; set; }
        public int Duurtijd { get; set; }
        public CabinePersoneelslid Cabinepersoneelslid{ get; set; }
        public CockpitPersoneelslid Cockpitpersoneelslid { get; set; }
        public Vliegtuigen Vliegtuig { get; set; }
        public Vliegmaatschappij Vliegmaatschappij { get; set; }

        private string toestelValue;
        public string Toestel {get; set;}
        public List<CockpitPersoneelslid> Cockpitpersoneelsleden { get; set; }
        public List<CabinePersoneelslid> Cabinepersoneelsleden { get; set; }
        public decimal BerekenVluchtKost()
        {
            decimal vliegtuigkost = Vliegtuig.BasisKostprijsPerDag;
            decimal cabinePersoneelskost = Cabinepersoneelslid.BerekenTotaleKostprijsperDag();
            decimal cockpitPersoneelskost = Cockpitpersoneelslid.BerekenTotaleKostprijsperDag();
            return (vliegtuigkost + cabinePersoneelskost + cockpitPersoneelskost) * Duurtijd;
           
        }
    }
}
