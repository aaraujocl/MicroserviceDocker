using Microsoft.EntityFrameworkCore;
using webapi_docker.Modelo;

namespace webapi_docker.Persistencia
{
    public class ContextoDocker: DbContext
    {
        public ContextoDocker() { }
        public ContextoDocker(DbContextOptions<ContextoDocker> options): base(options) { }

        public virtual DbSet<SubCategoria> SubCategoria { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }

    }
}
