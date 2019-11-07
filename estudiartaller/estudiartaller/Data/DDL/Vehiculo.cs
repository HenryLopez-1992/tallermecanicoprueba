using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace estudiartaller.Data.DDL
{
    public class Vehiculo
    {
        public int Id { get; set; }

        //  [Required]
        //   [MaxLength(10, ErrorMessage = "El campo {0} debe tener un maxiomo de {10} caracteres.")]
        public string NumeroPlaca { get; set; }

        // [Required]
        // [MaxLength(50, ErrorMessage = "El campo {0} debe tener un maxiomo de {50} caracteres.")]
        public string Descripcion { get; set; }

        // [Required]
        // [MaxLength(50, ErrorMessage = "El campo {0} debe tener un maxiomo de {50} caracteres.")]
        public string NumeroMotor { get; set; }

        //  [Required]
        // [MaxLength(50, ErrorMessage = "El campo {0} debe tener un maxiomo de {50} caracteres.")]

        public string NumeroChasis { get; set; }
        //llaves foraneas de muchos a uno
        public Cliente Cliente { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }
        // llaves nforaneas que se relacionan con tipovehiculo mediante el navegador
        //Los nombres que se lñe asignan a las llaves foraneas son las de aparecen en las tablas del explorador de archivos

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey ("TipoVehiculo")]
        public int TipoVehiculoId { get; set; }



    }
    }

