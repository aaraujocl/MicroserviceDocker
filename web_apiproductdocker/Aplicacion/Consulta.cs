using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using web_apiproductdocker.Modelo;
using web_apiproductdocker.Persistencia;
using Microsoft.EntityFrameworkCore;
using web_apiproductdocker.Service;
using web_apiproductdocker.Modelo.Dto;

namespace web_apiproductdocker.Aplicacion
{
    public class Consulta
    {
        public class ListaProducto: IRequest<List<ProductoDto>>
        {

        }

        public class Manejador : IRequestHandler<ListaProducto, List<ProductoDto>>
        {
            private readonly ContextoDocker _contexto;
            private readonly ICategoriaService _categoriaService;
            public Manejador(ContextoDocker contexto, ICategoriaService categoriaService)
            {
                _contexto = contexto;
                _categoriaService = categoriaService;
            }
            public async Task<List<ProductoDto>> Handle(ListaProducto request, CancellationToken cancellationToken)
            {
                List<ProductoDto> ListaProductDto = new List<ProductoDto>();

                var Lista = await _contexto.Producto.ToListAsync();               

                foreach(var item in Lista)
                {
                    var reponse = await _categoriaService.GetCategoriaID(item.Codfamilia);
                    if (reponse.Result)
                    {
                        //item.Categoria = reponse.Categoria;
                        var newproductdto = new ProductoDto
                        {
                            Categoria = reponse.Categoria,
                            Cantidadreorden = item.Cantidadreorden,
                            Codfamilia = item.Codfamilia,
                            Codigo = item.Codigo,
                            Codigobarraprincipal = item.Codigobarraprincipal,
                            Codimpuesto = item.Codimpuesto,
                            Codmarca = item.Codmarca,
                            Codnegocio = item.Codnegocio,
                            Codtipoproducto = item.Codtipoproducto,
                            Codunidadmedida = item.Codunidadmedida,
                            Color=item.Color,
                            Costounitario = item.Costounitario,
                            Descripcionlarga = item.Descripcionlarga,
                            Escompuesto=item.Escompuesto,
                            Esimpoconsumo=item.Esimpoconsumo,
                            Id = item.Id,
                            Imagen=item.Imagen,
                            Iva=item.Iva,
                            Ivaincluido=item.Ivaincluido,
                            Nomarticulo=item.Nomarticulo,
                            Peso=item.Peso,
                            Porcentajeimpoconsumo=item.Porcentajeimpoconsumo,
                            Precioconiva=item.Precioconiva,
                            Preciosugerido=item.Preciosugerido,
                            Referencia=item.Referencia,
                            Serial = item.Serial,
                            Status=item.Status,
                            Stock=item.Stock,
                            Stockmaximo=item.Stockmaximo,
                            Stockminimo=item.Stockminimo,
                            Talla=item.Talla,
                            Tipoiva=item.Tipoiva,
                            Valorimpoconsumo = item.Valorimpoconsumo    
                        };
                        ListaProductDto.Add(newproductdto);
                    }
                }

                return ListaProductDto;
            }
        }
    }
}
