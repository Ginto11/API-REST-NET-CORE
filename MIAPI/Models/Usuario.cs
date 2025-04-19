using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MIAPI.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("nombre")]
        public required string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        [Column("correo")]
        public required string Correo { get; set; }

        [Required]
        [StringLength(100)]
        [Column("clave")]
        public required string Clave { get; set; }

        [Required]
        [Column("id_rol")]
        public int RolId { get; set; }

        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; }

        public Rol? Rol { get; set; }
    }
}
