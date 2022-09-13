using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Personeel
{
    public abstract class Personeelslid : IKost
    {
        private int personeelslidIDValue;
        public int PersoneelslidID
        {
            get => personeelslidIDValue;
            set
            {
                if (value >= 0)
                    personeelslidIDValue = value;
                else
                    throw new Exception("PersoneelsID is verplicht");
            }
        }
        private string naamValue;
        public string Naam 
        { 
            get => naamValue; 
            set
            {
                if (value != null)
                    naamValue = value;
                else
                    throw new Exception("Naam is verplicht");
            }
        }

        public decimal BasisKostprijsPerDag {get; set; }
        public Personeelslid(int personeelslidID, string naam, decimal basisKostprijsPerDag)
        {
            PersoneelslidID = personeelslidID;
            Naam = naam;
            BasisKostprijsPerDag = basisKostprijsPerDag;
        }

        public abstract decimal BerekenTotaleKostprijsperDag();
       
        public override string ToString()
        {
            return $"{PersoneelslidID} - {Naam}";
;        }

    }
}
