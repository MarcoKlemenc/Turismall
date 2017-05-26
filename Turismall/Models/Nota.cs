﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Turismall.Models
{
    public class Nota
    {
        public int ID { get; set; }
        public string Texto { get; set; }

        public int ViajeID { get; set; }
        public virtual Viaje Viaje { get; set; }

        public string Foto { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe ingresarse la fecha correspondiente a la nota")]
        public DateTime Fecha { get; set; }
    }
}
