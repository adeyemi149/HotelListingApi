﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCountry_Redo.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual IList<Hotel> Hotels { get; set; }
    }
}
