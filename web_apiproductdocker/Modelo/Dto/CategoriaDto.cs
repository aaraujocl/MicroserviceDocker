using System.ComponentModel.DataAnnotations;

namespace web_apiproductdocker.Modelo.Dto
{
    public class CategoriaDto
    {
        [Key]
        public int Codfamilia { get; set; }
        public string Nomfamilia { get; set; }
        public string Url { get; set; }
        public int View { get; set; }
        public int Codnegocio { get; set; }
        public string Imagen { get; set; }
        public string Status { get; set; }
    }
}
