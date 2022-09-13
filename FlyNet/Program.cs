using System;
using FlyNet.Personeel;
using FlyNet.Vloot;
using System.IO;

namespace FlyNet
{
    public class Progam
    {
        public static void Main(string[] args)
        {
            List<Personeelslid> personeel = new List<Personeelslid>
            {
            new CockpitPersoneelslid(1, "Captain Kirk", 500m, Graad.Captain, 5000),
            new CockpitPersoneelslid(2, "Spock", 400m, Graad.SecondOfficer, 4500),
            new CabinePersoneelslid(3, "Pavel Checkov", 300m, Graad.Purser, "deur1"),
            new CabinePersoneelslid(4, "Luke Skywalker", 300m, Graad.Steward, "nooduitgang")
            };

            Vliegmaatschappij brusselsAirlines = new Vliegmaatschappij(1, Maatschappij.BrusselsAirlines);
            brusselsAirlines.Vloot = new List<Vliegtuig>
            {
                new Vliegtuig("Airbus A330-200", 870, 10800, 4000m),
                new Vliegtuig("Airbus A320", 840, 6100, 3000m)
            };
            Vliegmaatschappij tuiFly = new Vliegmaatschappij(2, Maatschappij.TUIFly);
            tuiFly.Vloot = new List<Vliegtuig>
            {
                 new Vliegtuig ("Boeing 737-800", 820, 6204, 2500m),
                 new Vliegtuig ("Boeing 787-300", 820, 6370, 2000m)
            };
            Vlucht ny = new Vlucht(1, "New York", 2, brusselsAirlines, brusselsAirlines.Vloot[0], personeel);
            Vlucht sy = new Vlucht(2, "Sydney", 3, tuiFly, tuiFly.Vloot[0], personeel);
            Vlucht si = new Vlucht(3, "Singapore", 1, brusselsAirlines, brusselsAirlines.Vloot[1], personeel);
            List<Vlucht> vluchten = new List<Vlucht> { ny, sy, si };


            foreach (var vlucht in vluchten)
            {
                Lijnentrekker lijn = new Lijnentrekker();
                lijn.TrekLijn(100, '=');
                Console.WriteLine($"VluchtID: {vlucht.VluchtID} - Bestemming {vlucht.Bestemming} ({vlucht.Duurtijd} dag(en))");
                lijn.TrekLijn(100, '=');
                Console.WriteLine($"Vliegmaatschappij: {vlucht.Vliegmaatschappij.MaatschappijNaam} - Toestel: {vlucht.Toestel.Type} (basis kostprijs per dag: {vlucht.Toestel.BasisKostprijsPerDag} euro)");
            }
        }
    }
}
