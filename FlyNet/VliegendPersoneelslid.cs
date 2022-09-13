using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Personeel
{
    public abstract class VliegendPersoneelslid : Personeelslid
    {
        public Graad Graad { get; set; }
        public Certificaat Certificaten { get; set; }
        public override abstract decimal BerekenTotaleKostprijsperDag();
        

    }
}
