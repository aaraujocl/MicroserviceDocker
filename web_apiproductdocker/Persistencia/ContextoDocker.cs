using Microsoft.EntityFrameworkCore;
using web_apiproductdocker.Modelo;

namespace web_apiproductdocker.Persistencia
{
    public class ContextoDocker : DbContext
    {
        public ContextoDocker(DbContextOptions<ContextoDocker> options) : base(options) { }

        public DbSet<Producto> Producto { get; set; }

    }
}
