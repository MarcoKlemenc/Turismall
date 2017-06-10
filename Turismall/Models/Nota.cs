using System;
using System.ComponentModel.DataAnnotations;

namespace Turismall.Models
{
    public class Nota
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Debe ingresarse texto correspondiente a la nota")]
        public string Texto { get; set; }

        public int ViajeID { get; set; }
        public virtual Viaje Viaje { get; set; }

        [Required(ErrorMessage = "Debe seleccionarse un destino")]
        public int DestinoID { get; set; }
        public virtual Destino Destino { get; set; }

        public string Foto { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe ingresarse la fecha correspondiente a la nota")]
        public DateTime Fecha { get; set; }
    }
}
