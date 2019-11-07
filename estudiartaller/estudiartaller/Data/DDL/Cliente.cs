using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace estudiartaller.Data.DDL
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un maxiomo de 50 caracteres.")]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo (0) debe tener un maxiomo de 50 caracteres.")]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "El campo (0) debe tener un maxiomo de 50 caracteres.")]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "El campo (0) debe tener un maxiomo de 50 caracteres.")]
        public string NIT { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "El campo (0) debe tener un maxiomo de 50 caracteres.")]
        public string Email { get; set; }

        //Llave Foranea de uno a muchos
        public ICollection<Vehiculo> Vehiculos { get; set; }
        

    }
}
