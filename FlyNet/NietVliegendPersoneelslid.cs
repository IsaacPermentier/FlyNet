using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Personeel
{
    public abstract class NietVliegendPersoneelslid : Personeelslid
    {
        public int UrenPerWeek { get; set; }
        public Afdeling Afdeling { get; set; }
        
        public override abstract decimal BerekenTotaleKostprijsperDag();
        
    }
}
