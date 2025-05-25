using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MIAPI.Models
{
    [Table("categorias")]
    public class Categoria
    {
        [Key]
        [Column("id_categoria")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        [Column("descripcion")]
        public required string Descripcion { get; set; }

        [JsonIgnore]
        public IEnumerable<Producto>? Productos {  get; set; } 
    }
}
