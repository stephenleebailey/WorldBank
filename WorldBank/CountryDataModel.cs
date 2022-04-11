using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBank
{
    public class CountryDataModel
    {
        public string Name { get; set; }
        public RegionDataModel Region { get; set; }
        public string CapitalCity { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public CountryDataModel()
        {
            Name = "";
            Region = new RegionDataModel();
            CapitalCity = "";
            Longitude = "";
            Latitude = "";
        }

    }
}