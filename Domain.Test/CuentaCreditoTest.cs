using Domain.Entities;
using NUnit.Framework;
using Domain.Factory;

namespace Domain.Test
{
    public class CuentaCreditoTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearCuentaCreditoTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Credito");
            cuenta.Numero = "111";
            cuenta.Nombre = "Corriente Ejemplo";
            cuenta.Ciudad = "Valledupar";
            Assert.AreEqual(1000000, cuenta.Saldo);
        }

        [Test]
        public void AbonarCuentaCreditoTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Credito");
            cuenta.Numero = "111";
            cuenta.Nombre = "Corriente Ejemplo";
            cuenta.Ciudad = "Valledupar";            
            cuenta.Retirar(new Transaccion(200000));
            cuenta.Consignar(new Transaccion(100000, "Valledupar"));
            Assert.AreEqual(900000, cuenta.Saldo);
        }

        [Test]
        public void AvanceCuentaCreditoTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Credito");
            cuenta.Numero = "111";
            cuenta.Nombre = "Corriente Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Retirar(new Transaccion(300000));
            Assert.AreEqual(700000, cuenta.Saldo);
        }
    }
}
