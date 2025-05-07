using System.ComponentModel.DataAnnotations;

namespace ClienteApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = default!;

        [Required, EmailAddress, MaxLength(150)]
        public string CorreoElectronico { get; set; } = default!;

        [Required, Phone, MaxLength(20)]
        public string Telefono { get; set; } = default!;
    }
}
