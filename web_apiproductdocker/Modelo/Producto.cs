using System.Xml.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using web_apiproductdocker.Modelo.Dto;

namespace web_apiproductdocker.Modelo
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
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
}
