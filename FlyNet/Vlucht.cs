using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlyNet.Vloot;
using FlyNet.Personeel;

namespace FlyNet
{
    public class Vlucht
    {
        public int VluchtID { get; set; }
        public string Bestemming { get; set; }
        public int Duurtijd { get; set; }
        public CabinePersoneelslid Cabinepersoneelslid{ get; set; }
        public CockpitPersoneelslid Cockpitpersoneelslid { get; set; }
        public Vliegmaatschappij Vliegmaatschappij { get; set; }
        public Vliegtuig Toestel {get; set;}
        public List<Personeelslid> Personeel { get; set; }
        public Vlucht(int vluchtID, string bestemming, int duurtijd, Vliegmaatschappij vliegmaatschappij, Vliegtuig toestel, List<Personeelslid> personeel)
        {
            VluchtID = vluchtID;
            Bestemming = bestemming;
            Vliegmaatschappij = vliegmaatschappij;
            Duurtijd = duurtijd;           
            Toestel = toestel;
            Personeel = personeel;
        }
        public decimal BerekenVluchtKost()
        {
            var persooneelTotaal = 0.00m;           
            var vliegtuigkost = Toestel.BasisKostprijsPerDag;
            foreach (VliegendPersoneelslid persoon in Personeel)
            {
                if (persoon is CockpitPersoneelslid)
                {
                    var perPersoon = persoon.BerekenTotaleKostprijsperDag();
                    persooneelTotaal += perPersoon;
                }
                if (persoon is CabinePersoneelslid)
                {
                    var perPersoon = persoon.BerekenTotaleKostprijsperDag();
                    persooneelTotaal += perPersoon;
                }
            };
            return (vliegtuigkost + persooneelTotaal) * Duurtijd;
           
        }
    }
}
