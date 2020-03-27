using Domain.Entities;
using NUnit.Framework;
using Domain.Factory;

namespace Domain.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CrearCuentaDeAhorroTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Ahorro");
            cuenta.Numero = "111";
            cuenta.Nombre = "Ahorro Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(50000, "Valledupar");
            Assert.AreEqual(50000, cuenta.Saldo);
        }

        [Test]
        public void ConsignarCuentaDeAhorroTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Ahorro");
            cuenta.Numero = "111";
            cuenta.Nombre = "Ahorro Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(50000, "Valledupar");
            cuenta.Retirar(20000);
            cuenta.Consignar(10000, "Valledupar");
            Assert.AreEqual(40000, cuenta.Saldo);
        }

        [Test]
        public void RetirarCuentaDeAhorroTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Ahorro");
            cuenta.Numero = "111";
            cuenta.Nombre = "Ahorro Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(50000, "Valledupar");
            cuenta.Retirar(30000);
            Assert.AreEqual(20000, cuenta.Saldo);
        }


    }
}