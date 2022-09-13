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
        public Maatschappij MaatschappijNaam { get; set; }
        public List<Vliegtuig> Vloot { get; set; }
        public Vliegmaatschappij(int vliegmaatschappijID, Maatschappij maatschappijNaam)
        {
            VliegmaatschappijID = vliegmaatschappijID;
            MaatschappijNaam = maatschappijNaam;
        }
    }   
}
