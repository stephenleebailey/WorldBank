using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBank
{
    public class RegionDataModel
    {
        public string Id { get; set; }
        public string iso2code { get; set; }
        public string value { get; set; }

        public RegionDataModel()
        {
            Id = "";
            iso2code = "";
            value = "";
        }
    }
}
