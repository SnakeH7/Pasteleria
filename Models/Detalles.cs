using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasteleria.Models
{
    public class Detalles
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        [ForeignKey("IdVenta")]
        public Ventas? Ventas { get; set; }
        public int IdPostre {  get; set; }
        [ForeignKey("IdPostre")]
        public Postres? Postres { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal (10,2)")]
        public decimal PrecioUnitario { get; set; }
    }
}
