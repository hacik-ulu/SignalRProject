using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.FeatureDto
{
    public class UpdateFeatureDto
    {
        public int FeatureID { get; set; }
        public string FirstTitle { get; set; }
        public string FirstDesc { get; set; }
        public string SecondTitle { get; set; }
        public string SecondDesc { get; set; }
        public string LastTitle { get; set; }
        public string LastDesc { get; set; }
    }
}
