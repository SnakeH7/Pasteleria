using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasteleria.Models
{
    public class Postres
    {
        [Key]
        public int IdPostre { get; set; }
        public string Postre { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioActual { get; set; }

        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categorias? Categorias { get; set; } //El signo de interrogación indica que puede ser null
    }
}
