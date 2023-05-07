using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using web_apiproductdocker.Persistencia;
using web_apiproductdocker.Modelo;

namespace web_apiproductdocker.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest<Unit>
        {
            public string Codigo { get; set; }
            public string Nomarticulo { get; set; }
            public int Codmarca { get; set; }
            public int Codfamilia { get; set; }
            public int Codunidadmedida { get; set; }
            public int Codimpuesto { get; set; }
            public int Codtipoproducto { get; set; }
            public string Codigobarraprincipal { get; set; }
            public string Serial { get; set; }
            public string Referencia { get; set; }
            public string Status { get; set; }
            public string Imagen { get; set; }
            public double Preciosugerido { get; set; }
            public double Iva { get; set; }
            public double Precioconiva { get; set; }
            public long Codnegocio { get; set; }
            public string Descripcionlarga { get; set; }
            public double Stockminimo { get; set; }
            public double Stockmaximo { get; set; }
            public double Cantidadreorden { get; set; }
            public double Peso { get; set; }
            public double Talla { get; set; }
            public double Costounitario { get; set; }
            public string Color { get; set; }
            public string Tipoiva { get; set; }
            public string Esimpoconsumo { get; set; }
            public double Valorimpoconsumo { get; set; }
            public double Porcentajeimpoconsumo { get; set; }
            public string Ivaincluido { get; set; }
            public Boolean Escompuesto { get; set; }
            public double Stock { get; set; }
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
                var producto = new Producto()
                {
                    Cantidadreorden = request.Cantidadreorden,
                    Codfamilia = request.Codfamilia,
                    Codigo= request.Codigo,
                    Codigobarraprincipal = request.Codigobarraprincipal,
                    Codimpuesto = request.Codimpuesto,
                    Codmarca = request.Codmarca,
                    Codnegocio = request.Codnegocio,
                    Codtipoproducto = request.Codtipoproducto,
                    Codunidadmedida = request.Codunidadmedida,
                    Color = request.Color,
                    Costounitario = request.Costounitario,
                    Descripcionlarga = request.Descripcionlarga,
                    Escompuesto = request.Escompuesto,
                    Esimpoconsumo = request.Esimpoconsumo,
                    Imagen = request.Imagen,
                    Iva=request.Iva,
                    Ivaincluido=request.Ivaincluido,
                    Nomarticulo=request.Nomarticulo,
                    Peso = request.Peso,
                    Porcentajeimpoconsumo=request.Porcentajeimpoconsumo,
                    Precioconiva = request.Precioconiva,
                    Preciosugerido=request.Preciosugerido,
                    Referencia=request.Referencia,
                    Serial = request.Serial,
                    Status = request.Status,
                    Stock = request.Stock,
                    Stockmaximo = request.Stockmaximo,
                    Stockminimo = request.Stockminimo,
                    Talla = request.Talla,
                    Tipoiva = request.Tipoiva,
                    Valorimpoconsumo = request.Valorimpoconsumo
                };

                _contexto.Producto.Add(producto);
                var valor = await _contexto.SaveChangesAsync();

                if (valor > 0)
                    return Unit.Value;

                throw new System.Exception("No se pudo insertar el producto");
            }


        }
    }
}
