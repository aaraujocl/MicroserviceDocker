using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using web_apiproductdocker.Aplicacion;
using web_apiproductdocker.Modelo.Dto;

namespace web_apiproductdocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);

        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> Listar()
        {
            return await _mediator.Send(new Consulta.ListaProducto());
        }
    }
}

