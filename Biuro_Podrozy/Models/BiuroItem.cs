﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Biuro_Podrozy.Models
{
    public class BiuroItem
    {
        public BiuroItem()
        {
            DepartureCities = new HashSet<DepartureCity>();
        }
        public int Id { get; set; }
        public string TravelPlace { get; set; }
        public decimal Price { get; set; }
        public int Seats { get; set; }
        public DateTime TravelDate { get; set; }

        public ICollection<DepartureCity> DepartureCities { get; set; }
    }
    public class DepartureCity
    {
        public DepartureCity()
        {
            BiuroItems = new HashSet<BiuroItem>();
        }
        public int DepartureCityId { get; set; }
        public string CityName { get; set; }
        public ICollection<BiuroItem> BiuroItems { get; set; }

    }
}