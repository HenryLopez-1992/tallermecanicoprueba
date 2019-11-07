using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using estudiartaller.Data.DDL;

namespace estudiartaller.Models
{
    public class estudiartallerContext : DbContext
    {
        public estudiartallerContext (DbContextOptions<estudiartallerContext> options)
            : base(options)
        {
        }

        public DbSet<estudiartaller.Data.DDL.Cliente> Cliente { get; set; }

        public DbSet<estudiartaller.Data.DDL.ServicioMecanico> ServicioMecanico { get; set; }

        public DbSet<estudiartaller.Data.DDL.TipoServicio> TipoServicio { get; set; }

        public DbSet<estudiartaller.Data.DDL.TipoVehiculo> TipoVehiculo { get; set; }

        public DbSet<estudiartaller.Data.DDL.Vehiculo> Vehiculo { get; set; }
    }
}
