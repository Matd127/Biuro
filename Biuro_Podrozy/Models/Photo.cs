using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoName { get; set;}

        public ICollection<BiuroItem> BiuroItems { get; set; }
    }
}
