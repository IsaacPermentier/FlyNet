using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyNet.Vloot
{
    public class Vliegmaatschappij
    {
        public int VliegmaatschappijID { get; set; }
        public Maatschappij Maatschappij { get; set; }
        public Vliegmaatschappij(int vliegmaatschappijID, Maatschappij maatschappij)
        {
            VliegmaatschappijID = vliegmaatschappijID;
            Maatschappij = maatschappij;
        }
        public List<Vliegtuigen> Vloot { get; set; }

    }   
}
