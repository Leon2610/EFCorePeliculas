using System.ComponentModel.DataAnnotations;

namespace EFCorePeliculas.DTOs
{
    public class CineOfertaCreacionDTO
    {
        [Range(1, 100)]
        public double PorcentajeDescuento { get; set; }
        public DateTime FechaIncio { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
