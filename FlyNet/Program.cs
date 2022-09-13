using System;
using FlyNet.Personeel;
using FlyNet.Vloot;

namespace FlyNet
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            List<CockpitPersoneelslid> cockpitpersoneel = new List<CockpitPersoneelslid>
            {
            new CockpitPersoneelslid {PersoneelslidID = 1, Naam = "Captain Kirk", BasisKostprijsPerDag = 500m, Graad = Graad.Captain, Vlieguren = 500 },
            new CockpitPersoneelslid {PersoneelslidID = 2, Naam = "Spock", BasisKostprijsPerDag = 400m, Graad = Graad.SecondOfficer, Vlieguren = 500 }
            };

            List<CabinePersoneelslid> cabinepersoneel = new List<CabinePersoneelslid>
            {
            new CabinePersoneelslid {PersoneelslidID = 3, Naam = "Pavel Checkov", BasisKostprijsPerDag = 300m, Graad = Graad.Purser, Werkpositie = "deur1" },
            new CabinePersoneelslid {PersoneelslidID = 4, Naam = "Luke Skywalker", BasisKostprijsPerDag = 300m, Graad = Graad.Steward, Werkpositie = "nooduitgang" }
            };
            
            Vliegmaatschappij brusselsAirlines = new Vliegmaatschappij(1, Maatschappij.BrusselsAirlines);
            brusselsAirlines.Vloot = new List<Vliegtuigen>
            {
                new Vliegtuigen{Type = "Airbus A330-200", Kruissnelheid = 870, Vliegbereik = 10800, BasisKostprijsPerDag = 4000m },
                new Vliegtuigen{Type = "Airbus A320", Kruissnelheid = 840, Vliegbereik = 6100, BasisKostprijsPerDag = 3000m }
            };
            Vliegmaatschappij tuiFly = new Vliegmaatschappij(2, Maatschappij.TUIFly);
            tuiFly.Vloot = new List<Vliegtuigen>
            {
                 new Vliegtuigen {Type = "Boeing 737-800", Kruissnelheid = 820, Vliegbereik = 6204, BasisKostprijsPerDag = 2500m},
                 new Vliegtuigen {Type = "Boeing 787-300", Kruissnelheid = 820, Vliegbereik = 6370, BasisKostprijsPerDag = 2000m}
            };
            Console.WriteLine(brusselsAirlines.Vloot[0].Type);

            List<Vluchten> vluchten = new List<Vluchten>
            {
                new Vluchten {VluchtID = 1, Bestemming = "New York", Vliegmaatschappij = brusselsAirlines, Toestel = brusselsAirlines.Vloot[0].Type, Duurtijd = 2, Cockpitpersoneelsleden = cockpitpersoneel[0].Naam, Cabinepersoneelsleden = cabinepersoneel}
            };
            Console.WriteLine(vluchten[0]);

        }
    }
}
