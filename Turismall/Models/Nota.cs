using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismall.Models
{
    public class Nota
    {
        public int ID { get; set; }
        public string texto { get; set; }
        public Viaje viaje { get; set; }
    }
}
