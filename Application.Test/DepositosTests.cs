using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Test
{
    public class DepositosTests
    {
        BancoContext _context;

        [SetUp]
        public void Setup()
        {
            var optionsSqlServer = new DbContextOptionsBuilder<BancoContext>()
             .UseSqlServer("Server=DESKTOP-N95GP02\\SQLEXPRESS;Database=Banco;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;

            /*var optionsInMemory = new DbContextOptionsBuilder<BancoContext>().UseInMemoryDatabase("Banco").Options;*/

            _context = new BancoContext(optionsSqlServer);
        }

        [Test]
        public void CrearCDTTest()
        {
            //Creacion
            var createRequest = new CrearDepositoRequest { Numero = "2113", Nombre = "aaaaa", TipoCuenta = "CDT", Periodo = 7, TasaDeInteres = 0.06 };
            CrearDepositoService _createService = new CrearDepositoService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual($"Se creó con exito el {createRequest.TipoCuenta} No {createRequest.Numero}.", createResponse.Mensaje);
        }
    }
}
