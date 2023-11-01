using Consultorio_Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Consultorio_Backend.Data
{
    public class ConsultorioDBContext : DbContext
    {
        public ConsultorioDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Asegurado> Asegurados { get; set; }

        public DbSet<Seguro> Seguros { get; set; }


    }
}
