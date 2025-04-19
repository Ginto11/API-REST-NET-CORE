using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MIAPI.Models
{
    [Table("productos")]
    public class Producto
    {
        [Key]
        [Column("id_producto")]
        public int Id { get; set; }

        [Required]
        [Column("nombre")]
        [StringLength(100)]
        public required string Nombre { get; set; }

        [Required]
        [Column("descripcion")]
        [StringLength(100)]
        public required string Descripcion { get; set;}

        [Required]
        [Column("id_categoria")]
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        
    }

}

