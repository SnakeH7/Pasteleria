using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Pasteleria.Models
{
    public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuarios? Usuarios { get; set; } //El signo de interrogación acepta valores null
        public DateTime FechaVenta { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total {  get; set; }
        [JsonIgnore]
        public ICollection<Detalles>? Detalles { get; set; }
    }
}
