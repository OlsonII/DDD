using Domain.Entities;
using NUnit.Framework;
using Domain.Factory;

namespace Domain.Test
{
    public class CuentaCorrienteTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearCuentaCorrienteTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Corriente");
            cuenta.Numero = "111";
            cuenta.Nombre = "Corriente Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(new Transaccion(100000, "Valledupar"));
            Assert.AreEqual(100000, cuenta.Saldo);
        }

        [Test]
        public void ConsignarCuentaCorrienteTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Corriente");
            cuenta.Numero = "111";
            cuenta.Nombre = "Corriente Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(new Transaccion(100000, "Valledupar"));
            cuenta.Consignar(new Transaccion(40000, "Valledupar"));
            Assert.AreEqual(140000, cuenta.Saldo);
        }

        [Test]
        public void RetirarCuentaCorrienteTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Corriente");
            cuenta.Numero = "111";
            cuenta.Nombre = "Corriente Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(new Transaccion(100000, "Valledupar"));
            cuenta.Retirar(new Transaccion(30000));
            Assert.AreEqual(100000 - (30000 + (30000*4/1000)), cuenta.Saldo);
        }
    }
}
