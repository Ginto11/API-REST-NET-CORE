using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MIAPI.Models
{
    [Table("roles")]
    public class Rol
    {
        [Key]
        [Column("id_rol")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [JsonIgnore]
        public IEnumerable<Usuario>? Usuarios { get; set; }
    }
}
