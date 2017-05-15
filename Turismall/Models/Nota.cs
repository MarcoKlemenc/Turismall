﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismall.Models
{
    public class Nota
    {
        public int ID { get; set; }
        public string texto { get; set; }

        public int ViajeID { get; set; }
        public virtual Viaje Viaje { get; set; }
    }
}
