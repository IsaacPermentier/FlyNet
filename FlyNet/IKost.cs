using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet
{
    public interface IKost
    {
        public decimal BasisKostprijsPerDag { get; }
        public decimal BerekenTotaleKostprijsperDag();
    }
}
