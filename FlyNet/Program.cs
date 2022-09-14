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
            Certificaat PPL = new Certificaat
            {
                CertificaatAfkorting = "PPL",
                CertificaatOmschrijving = "Private Pilot License"
            };


            Certificaat ATPL = new Certificaat
            {
                CertificaatAfkorting = "ATPL",
                CertificaatOmschrijving = "Airline Transport Pilot License"
            };

            Certificaat IR = new Certificaat
            {
                CertificaatAfkorting = "IR",
                CertificaatOmschrijving = "Instrument Rating"
            };

            Certificaat CPL = new Certificaat
            {
                CertificaatAfkorting = "CPL",
                CertificaatOmschrijving = "Commercial Pilot License"
            };

            Certificaat ME = new Certificaat
            {
                CertificaatAfkorting = "ME",
                CertificaatOmschrijving = "Multi Engine"
            };

            Certificaat MCC = new Certificaat
            {
                CertificaatAfkorting = "MCC",
                CertificaatOmschrijving = "Multi Crew Concept"
            };

            Certificaat EHBO = new Certificaat
            {
                CertificaatAfkorting = "EHBO",
                CertificaatOmschrijving = "First Aid"
            };

            Certificaat EVAC = new Certificaat
            {
                CertificaatAfkorting = "EVAC",
                CertificaatOmschrijving = "Evacution Procedures"
            };

            Certificaat FIRE = new Certificaat
            {
                CertificaatAfkorting = "FIRE",
                CertificaatOmschrijving = "Fire Fighting"
            };


            Certificaat SURV = new Certificaat
            {
                CertificaatAfkorting = "SURV",
                CertificaatOmschrijving = "Survival"
            };


            Certificaat IFS = new Certificaat
            {
                CertificaatAfkorting = "IFS",
                CertificaatOmschrijving = "In Flight Service"
            };

            List<Personeelslid> personeel = new List<Personeelslid>
            {
            new CockpitPersoneelslid(1, "Captain Kirk", 500m, Graad.Captain, new List<Certificaat>{PPL, ATPL, CPL, SURV }, 5000),
            new CockpitPersoneelslid(2, "Spock", 400m, Graad.SecondOfficer, new List<Certificaat>{PPL, ATPL, CPL, IFS}, 4500),
            new CabinePersoneelslid(3, "Pavel Checkov", 300m, Graad.Purser, new List<Certificaat>{ME, MCC, EHBO, IFS}, "deur1"),
            new CabinePersoneelslid(4, "Luke Skywalker", 300m, Graad.Steward, new List<Certificaat>{FIRE, SURV, IFS, EHBO}, "nooduitgang")
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
            Vlucht ny = new Vlucht(1, "New York", 2, brusselsAirlines, brusselsAirlines.Vloot[0], new List<Personeelslid> { personeel[0], personeel[1], personeel[2] });
            Vlucht sy = new Vlucht(2, "Sydney", 3, tuiFly, tuiFly.Vloot[0], new List<Personeelslid> { personeel[0], personeel[1], personeel[3] });
            Vlucht si = new Vlucht(3, "Singapore", 1, brusselsAirlines, brusselsAirlines.Vloot[1], new List<Personeelslid> { personeel[0], personeel[3] });
            List<Vlucht> vluchten = new List<Vlucht> { ny, sy, si };

            foreach (var vlucht in vluchten)
            {
                var cockpitTotaal = 0.00m;
                var cabineTotaal = 0.00m;
                var personeelTotaal = 0.00m;
                foreach (VliegendPersoneelslid persoon in vlucht.Personeel)
                {
                    if (persoon is CockpitPersoneelslid)
                    {
                        var perPersoon = persoon.BerekenTotaleKostprijsperDag() * vlucht.Duurtijd;
                        cockpitTotaal += perPersoon;
                        personeelTotaal += perPersoon;
                    }
                    if (persoon is CabinePersoneelslid)
                    {
                        var perPersoon = persoon.BerekenTotaleKostprijsperDag() * vlucht.Duurtijd;
                        cabineTotaal += perPersoon;
                        personeelTotaal += perPersoon;
                    }
                };
                Lijnentrekker lijn = new Lijnentrekker();
                lijn.TrekLijn(100, '=');
                Console.WriteLine($"VluchtID: {vlucht.VluchtID} - Bestemming {vlucht.Bestemming} ({vlucht.Duurtijd} dag(en))");
                lijn.TrekLijn(100, '=');
                Console.WriteLine($"Vliegmaatschappij: {vlucht.Vliegmaatschappij.MaatschappijNaam} - Toestel: {vlucht.Toestel.Type} (basis kostprijs per dag: {vlucht.Toestel.BasisKostprijsPerDag} euro)");
                Console.WriteLine($"Vluchtprijs: {vlucht.BerekenVluchtKost()} euro");
                Console.WriteLine();
                Console.WriteLine($"Totale vliegtuigkost: {vlucht.Toestel.BasisKostprijsPerDag * vlucht.Duurtijd}");
                Console.WriteLine($"Totale personeelskost: {personeelTotaal} euro");
                Console.WriteLine($"  Totale kost cockpitpersoneel: {cockpitTotaal} euro");
                Console.WriteLine($"  Totale kost cabinepersoneel: {cabineTotaal} euro");
                Console.WriteLine();
                Console.WriteLine("Cockpitpersoneel");
                lijn.TrekLijn(18, '-');
                foreach (VliegendPersoneelslid persoon in vlucht.Personeel)
                    if (persoon is CockpitPersoneelslid)
                    {
                        persoon.Afbeelden();
                        Console.WriteLine();
                    }
                Console.WriteLine("Cabinepersoneel");
                lijn.TrekLijn(18, '-');
                foreach (VliegendPersoneelslid persoon in vlucht.Personeel)
                    if (persoon is CabinePersoneelslid)
                    {
                        persoon.Afbeelden();
                        Console.WriteLine();
                    }
            }
        }
    }
}
