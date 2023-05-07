using System.Threading.Tasks;
using web_apiproductdocker.Modelo.Dto;

namespace web_apiproductdocker.Service
{
    public interface ICategoriaService
    {
        Task<Response> GetCategoriaID(int Id);
    }
}
