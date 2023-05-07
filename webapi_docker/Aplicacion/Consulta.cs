using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using webapi_docker.Modelo;
using webapi_docker.Persistencia;

namespace webapi_docker.Aplicacion
{
    public class Consulta
    {
        public class ListaCategoria: IRequest<List<Categoria>>
        {

        }

        public class Manejador : IRequestHandler<ListaCategoria, List<Categoria>>
        {
            public readonly ContextoDocker _contexto;
            public Manejador(ContextoDocker contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<Categoria>> Handle(ListaCategoria request, CancellationToken cancellationToken)
            {
                var Lista = await _contexto.Categoria.ToListAsync();

                return Lista;
            }
        }

    }
}
