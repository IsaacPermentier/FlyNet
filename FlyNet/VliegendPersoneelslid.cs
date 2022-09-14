using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Personeel
{
    public abstract class VliegendPersoneelslid : Personeelslid
    {
        public virtual Graad Graad { get; set; }
        public List<Certificaat> Certificaten { get; set; }
        public VliegendPersoneelslid(int personeelslidID, string naam, decimal basisKostprijsPerDag, Graad graad, List<Certificaat> certificaten)
            : base(personeelslidID, naam, basisKostprijsPerDag)
        {
            Graad = graad;
            Certificaten = certificaten;
        }
        public override abstract decimal BerekenTotaleKostprijsperDag();
        public override string ToString()
        {
            return @$"00{PersoneelslidID} - {Naam} (basiskostprijs per dag: {BasisKostprijsPerDag} euro)
Graad: {Graad}
Certificaten: {Certificaten}";
        }
        public virtual void Afbeelden()
        {
            Console.WriteLine($"00{PersoneelslidID} - {Naam} (basiskostprijs per dag: {BasisKostprijsPerDag} euro)");
            Console.WriteLine($"Graad: {Graad}");
            Console.WriteLine("Certificaten: ");
            foreach (var certificaat in Certificaten)
                Console.WriteLine($"   {certificaat.CertificaatOmschrijving} ({certificaat.CertificaatAfkorting})");
        }
    }
}
   