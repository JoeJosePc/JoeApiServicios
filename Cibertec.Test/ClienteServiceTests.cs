using Cibertec.Business;
using Cibertec.Models;
using Cibertec.Repository;
using Cibertec.UnitOfWork;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Cibertec.Test
{
    public class ClienteServiceTests
    {
        IUnitOfWork _unitOfWork;
        ProductoBusiness _productoService;
        public ClienteServiceTests()
        {
            _unitOfWork = GetInstance();
            _productoService = new ProductoBusiness(GetInstance());
        }

        private IUnitOfWork GetInstance()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(c => c.productos)
                .Returns(GetClienteMocked());

            return mock.Object;
        }

        private IProductoRepository GetClienteMocked()
        {
            var clientesMock = new Mock<IProductoRepository>();
            clientesMock.Setup(c => c.GetList())
                        .Returns(GetClienteList());



            return clientesMock.Object;
        }

        private List<Producto> GetClienteList()
        {
            return new List<Producto>()
            {
                new Producto {Id=1, Descripcion="Primer Apellido 1", Archivo="Last Name 1" }

            };
        }

        private List<Producto> GetEmptyClienteList()
        {
            return new List<Producto>();
        }

        [Fact(DisplayName = "GetList_Should_be_Ok")]
        public void GetList_Should_be_Ok()
        {
            var lista = _productoService.GetProductos();
            lista.Should().NotBeNullOrEmpty();
        }

    }
}
