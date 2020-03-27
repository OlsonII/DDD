using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Test
{
    public class CuentasBancariasTests
    {
        BancoContext _context;

        [SetUp]
        public void Setup()
        {
            /*var optionsSqlServer = new DbContextOptionsBuilder<BancoContext>()
             .UseSqlServer("Server=.\\;Database=Banco;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;*/

            var optionsInMemory = new DbContextOptionsBuilder<BancoContext>().UseInMemoryDatabase("Banco").Options;

            _context = new BancoContext(optionsInMemory);            
        }

        [Test]
        public void CrearCuentaBancariaTest()
        {
            var request = new CrearCuentaBancariaRequest { Numero = "1113", Nombre = "aaaaa", TipoCuenta = "Ahorro" };
            CrearCuentaBancariaService _service = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Se creó con exito la cuenta 1113.", response.Mensaje);
        }

        [Test]
        public void ConsignarCuentaAhorroTest()
        {
            var request = new CrearCuentaBancariaRequest { Numero = "1112", Nombre = "aaaaa", TipoCuenta = "Ahorro" };
            CrearCuentaBancariaService _service = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            //Assert.AreEqual("Se creó con exito la cuenta 1111.", response.Mensaje);
            Assert.AreEqual(request.TipoCuenta, response.TipoDeCuentaCreado);

            var requestConsignar = new ConsignarRequest { NumeroCuenta = "1112", Valor = 100000 };
            var serviceConsignar = new ConsignarService(new UnitOfWork(_context));
            var responseConsignar = serviceConsignar.Ejecutar(requestConsignar);
            Assert.AreEqual($"Su Nuevo saldo es {requestConsignar.Valor}.", responseConsignar.Mensaje);                        
        }
    }
}