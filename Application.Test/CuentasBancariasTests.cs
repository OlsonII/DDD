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
            var optionsSqlServer = new DbContextOptionsBuilder<BancoContext>()
             .UseSqlServer("Server=DESKTOP-N95GP02\\SQLEXPRESS;Database=Banco;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;

            /*var optionsInMemory = new DbContextOptionsBuilder<BancoContext>().UseInMemoryDatabase("Banco").Options;*/

            _context = new BancoContext(optionsSqlServer);  
        }

        #region Tests Cuentas de Ahorro

        [Test]
        public void CrearCuentaAhorroTest()
        {
            //Creacion
            var createRequest = new CrearCuentaBancariaRequest { Numero = "1113", Nombre = "aaaaa", Ciudad = "Valledupar", TipoCuenta = "Ahorro" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual("Se cre� con exito la cuenta 1113.", createResponse.Mensaje);
        }

        [Test]
        public void ConsignarCuentaAhorroTest()
        {            
            //Consignacion
            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "1113", Ciudad = "Valledupar", Valor = 100000 };            
            var consignarResponse = _consignarService.Ejecutar(consignarRequest);
            Assert.AreEqual($"Su Nuevo saldo es {consignarRequest.Valor}.", consignarResponse.Mensaje);                        
        }

        [Test]
        public void RetirarCuentaAhorroTest()
        {          
            //Retiro
            RetirarService _retirarService = new RetirarService(new UnitOfWork(_context));
            var retirarRequest = new RetirarRequest { NumeroCuenta = "1113", Valor = 50000 };

            var retirarResponse = _retirarService.Ejecutar(retirarRequest);

            Assert.AreEqual($"Su Nuevo saldo es 50000.", retirarResponse.Mensaje);
        }

        #endregion

        #region Tests Cuentas Corrientes
        [Test]
        public void CrearCuentaCorrienteTest()
        {
            //Creacion
            var createRequest = new CrearCuentaBancariaRequest { Numero = "1114", Nombre = "aaaaa", Ciudad = "Valledupar", TipoCuenta = "Corriente" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual("Se cre� con exito la cuenta 1114.", createResponse.Mensaje);
        }

        [Test]
        public void ConsignarCuentaCorrienteTest()
        {
            //Consignacion
            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "1114", Ciudad = "Valledupar", Valor = 100000 };
            var consignarResponse = _consignarService.Ejecutar(consignarRequest);
            Assert.AreEqual($"Su Nuevo saldo es {consignarRequest.Valor}.", consignarResponse.Mensaje);
        }

        [Test]
        public void RetirarCuentaCorrienteTest()
        {
            //Retiro
            RetirarService _retirarService = new RetirarService(new UnitOfWork(_context));
            var retirarRequest = new RetirarRequest { NumeroCuenta = "1114", Valor = 50000 };

            var retirarResponse = _retirarService.Ejecutar(retirarRequest);

            Assert.AreEqual($"Su Nuevo saldo es 49800.", retirarResponse.Mensaje);
        }

        #endregion

        #region Tests Cuentas de Credito

        [Test]
        public void CrearCuentaCreditoTest()
        {
            //Creacion
            var createRequest = new CrearCuentaBancariaRequest { Numero = "1115", Nombre = "aaaaa", Ciudad = "Valledupar", TipoCuenta = "Credito" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual("Se cre� con exito la cuenta 1115.", createResponse.Mensaje);
        }

        [Test]
        public void RetirarCuentaCreditoTest()
        {

            //Retiro
            RetirarService _retirarService = new RetirarService(new UnitOfWork(_context));
            var retirarRequest = new RetirarRequest { NumeroCuenta = "1115", Valor = 300000 };

            var retirarResponse = _retirarService.Ejecutar(retirarRequest);
            Assert.AreEqual($"Su Nuevo saldo es 700000.", retirarResponse.Mensaje);
        }

        [Test]
        public void ConsignarCuentaCreditoTest()
        {
            //Consignacion
            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "1115", Ciudad = "Valledupar", Valor = 200000 };

            var consignarResponse = _consignarService.Ejecutar(consignarRequest);

            Assert.AreEqual($"Su Nuevo saldo es 900000.", consignarResponse.Mensaje);
        }       

        #endregion
    }
}