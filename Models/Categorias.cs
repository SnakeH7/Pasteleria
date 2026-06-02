using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Pasteleria.Models
{
    public class Categorias //Forma de realizar una migracion desde EF hacia SQL Server
    {
        [Key]
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Postres>? Postres {  get; set; }
    }
}
