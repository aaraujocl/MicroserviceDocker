using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webapi_docker.Aplicacion;
using webapi_docker.Modelo;
using webapi_docker.Persistencia;
using Xunit;
using static webapi_docker.Aplicacion.Consulta;
using static webapi_docker.Aplicacion.ConsultaPorId;
using Manejador = webapi_docker.Aplicacion.ConsultaPorId.Manejador;

namespace web_apidocker.Test
{
    public class CategoriaServiceTest
    {
        private IEnumerable<Categoria> ObtenerListaCategorias()
        {
            A.Configure<Categoria>()
                .Fill(x => x.Nomfamilia).AsArticleTitle()
                .Fill(x => x.Codfamilia).WithinRange(1, 31)
                .Fill(x => x.View).WithinRange(0, 0)
                .Fill(x => x.Status).AsUsaState()
                .Fill(x => x.Url).AsEmailAddress();


            var List= A.ListOf<Categoria>(31);
            return List;
        }

        private Mock<ContextoDocker> CrearContexto()
        {
            var dataPrueba = ObtenerListaCategorias().AsQueryable();

            var dbSet = new Mock<DbSet<Categoria>>();

            dbSet.As<IQueryable<Categoria>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);

            dbSet.As<IQueryable<Categoria>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);
            
            dbSet.As<IQueryable<Categoria>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);

            dbSet.As<IQueryable<Categoria>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());

            dbSet.As<IAsyncEnumerable<Categoria>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<Categoria>(dataPrueba.GetEnumerator()));

            dbSet.As<IQueryable<Categoria>>().Setup(x => x.Provider).Returns(new AsyncQueryProvider<Categoria>(dataPrueba.Provider));

            var contexto = new Mock<ContextoDocker>();
            contexto.Setup(x=>x.Categoria).Returns(dbSet.Object);
            return contexto;
        }


        [Fact]
        public async void GetCategoriasByID()
        {
            System.Diagnostics.Debugger.Launch();

            var mockContexto = CrearContexto();

            var Manejador = new ConsultaPorId.Manejador(mockContexto.Object);

            var request = new ConsultaPorId.BuscarCategoriaPorID() { Id = 17};

            var categoria = await Manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.NotNull(categoria);
            Assert.True(categoria.Codfamilia == 17);

        }

            [Fact]
        public async void GetCategorias()
        {
            System.Diagnostics.Debugger.Launch();

            //Que metodo es el encargado de hacer la consulta a la base de datos para obtener las categorias
            //1.- Emular a la instancia de entityFramework en un ambiente de Test
            //2.- Crear un Objeto Manejador
            //Utilicemos un objetos Mock

            var moqContexto = CrearContexto();

            var Manejador = new Consulta.Manejador(moqContexto.Object);

            ListaCategoria request = new Consulta.ListaCategoria();

            var lista = await Manejador.Handle(request, new System.Threading.CancellationToken());

            Assert.True(lista.Any());

        }

    }
}
