using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using webapi_docker.Modelo;
using webapi_docker.Persistencia;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace webapi_docker.Aplicacion
{
    public class ConsultaPorId
    {
        public class BuscarCategoriaPorID : IRequest<Categoria>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<BuscarCategoriaPorID, Categoria>
        {
            public readonly ContextoDocker _contexto;
            public Manejador(ContextoDocker contexto)
            {
                _contexto = contexto;
            }
            public async Task<Categoria> Handle(BuscarCategoriaPorID request, CancellationToken cancellationToken)
            {
                var Categoria = await _contexto.Categoria.Where(x=> x.Codfamilia == request.Id).FirstAsync();

                return Categoria;
            }
        }
    }
}
