using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class DepartureCity
    {
        public DepartureCity() {
            BiuroItems = new HashSet<BiuroItem>();
        }
        public int DepartureCityId { get; set; }
        public string CityName { get; set; }

        public ICollection<BiuroItem> BiuroItems { get; set; }
    }
}
