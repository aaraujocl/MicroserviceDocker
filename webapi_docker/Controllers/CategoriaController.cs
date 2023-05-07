using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_docker.Aplicacion;
using webapi_docker.Modelo;

namespace webapi_docker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);

        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Listar()
        {
            return await _mediator.Send(new Consulta.ListaCategoria());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Categoria>> GetId(int Id)
        {
            return await _mediator.Send(new ConsultaPorId.BuscarCategoriaPorID() { Id= Id});
        }
    }
}
