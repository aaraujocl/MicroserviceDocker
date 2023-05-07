using MediatR;
using System.Threading;
using System.Threading.Tasks;
using webapi_docker.Modelo;
using webapi_docker.Persistencia;

namespace webapi_docker.Aplicacion
{
    public class Nuevo
    {

        public class Ejecuta: IRequest<Unit>
        {
            public string Nomfamilia { get; set; } 
            public string Url { get; set; }
            public int View { get; set; }
            public int Codnegocio { get; set; }
            public string Imagen { get; set; }
            public string Status { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            public readonly ContextoDocker _contexto;
            public Manejador(ContextoDocker contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var categoria = new Categoria() { 
                 Codnegocio = request.Codnegocio,
                 Imagen = request.Imagen,
                 Nomfamilia = request.Nomfamilia,
                 Url = request.Url,
                 Status = request.Status,
                 View = request.View
                };

                _contexto.Categoria.Add(categoria);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0 )
                    return Unit.Value;

                throw new System.Exception("No se pudo insertar la categoria");
            }

      
        }
    }
}
