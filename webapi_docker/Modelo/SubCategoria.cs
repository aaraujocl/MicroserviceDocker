using System;
using System.ComponentModel.DataAnnotations;

namespace webapi_docker.Modelo
{
    public class SubCategoria
    {
        [Key]
        public int Codsubfamilia { get; set; }

        public string Nombre { get; set; }

        public int Codfamilia { get; set; }

        public string Imagen { get; set; }

        public string Url { get; set; }

        public int View { get; set; }

        public int Codnegocio { get; set; }

        public string Status { get; set; }

        private Categoria Familia;
    }
}
