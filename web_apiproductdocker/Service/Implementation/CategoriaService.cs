using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using web_apiproductdocker.Modelo.Dto;

namespace web_apiproductdocker.Service.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IHttpClientFactory _httpClientFactory; 
        private readonly ILogger<CategoriaService> _logger;

        public CategoriaService(IHttpClientFactory httpClientFactory, ILogger<CategoriaService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<Response> GetCategoriaID(int Id)
        {
            try
            {
                var cliente = _httpClientFactory.CreateClient("Categoria");
                var response = await cliente.GetAsync($"api/Categoria/{Id}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<CategoriaDto>(contenido, options);

                    return new Response()
                    {
                        Result = true,
                        Categoria = resultado,
                        Message = null
                    };
                }

                return new Response() { Result = false, Categoria = null, Message=response.ReasonPhrase };
            }
            catch (Exception e) {

                _logger?.LogError(e.ToString());
                return new Response() { Result = false, Categoria = null, Message = e.Message };
            }
        }
    }
}
