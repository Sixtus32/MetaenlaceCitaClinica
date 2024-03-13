using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MetaenlaceCitaClinica.Models.Entity
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "NOMBRE")]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "APELLIDOS")]
        public string? Apellidos { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "NOMBRE DE USUARIO")]
        public string? UsuarioNom { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "CLAVE")]
        public string? Clave { get; set; }
    }
}
