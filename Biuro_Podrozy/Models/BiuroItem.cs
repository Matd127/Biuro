using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biuro_Podrozy.Models
{
    public class BiuroItem
    {
        public BiuroItem(){
            DepartureCities = new HashSet<DepartureCity>();
        }

        public int Id { get; set; }
        public string TravelPlace { get; set; }
        public decimal Price { get; set; }
        public int Seats { get; set; }
        public DateTime TravelDate { get; set; }
        
        public Photo Photos { get; set; }
        public ICollection<DepartureCity> DepartureCities { get; set;}
    }

    
}