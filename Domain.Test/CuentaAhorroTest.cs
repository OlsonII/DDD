using Domain.Entities;
using NUnit.Framework;
using Domain.Factory;
using System.Collections.Generic;

namespace Domain.Test
{
    public class CuentaDeAhorroTest
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
            cuenta.Consignar(new Transaccion(50000, "Valledupar"));
            Assert.AreEqual(50000, cuenta.Saldo);
        }


        [Test]
        public void ConsignarCuentaDeAhorroTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Ahorro");
            cuenta.Numero = "111";
            cuenta.Nombre = "Ahorro Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(new Transaccion(50000, "Valledupar"));
            cuenta.Retirar(new Transaccion(20000, "Valledupar"));
            cuenta.Consignar(new Transaccion(10000, "Valledupar"));
            Assert.AreEqual(40000, cuenta.Saldo);
        }

        [Test]
        [TestCase("0101", "Cuenta #1", 100000, 100000, TestName = "Consignacion de 100000")]
        [TestCase("0101", "Cuenta #2", 200000, 200000, TestName = "Consignacion de 200000")]
        [TestCase("0101", "Cuenta #3", 300000, 300000, TestName = "Consignacion de 300000")]
        [TestCase("0101", "Cuenta #4", 400000, 400000, TestName = "Consignacion de 400000")]
        public void ConsignacionExitosaCuentaDeAhorroTest(string numeroCuenta, string nombreCuenta, double valorConsignar, double saldoEsperado)
        {
            var cuenta = new CuentaBancariaFactory().Create("Ahorro");
            cuenta.Numero = numeroCuenta;
            cuenta.Nombre = nombreCuenta;
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(new Transaccion(valorConsignar, "Valledupar"));
            Assert.AreEqual(saldoEsperado, cuenta.Saldo);
        }

        [TestCaseSource("DataSourceConsignacion")]
        public void ConsignacionExitosaCuentaDeAhorroTestWithCaseSource(string numeroCuenta, string nombreCuenta, double valorConsignar, double saldoEsperado)
        {
            var cuenta = new CuentaBancariaFactory().Create("Ahorro");
            cuenta.Numero = numeroCuenta;
            cuenta.Nombre = nombreCuenta;
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(new Transaccion(valorConsignar, "Valledupar"));
            Assert.AreEqual(saldoEsperado, cuenta.Saldo);
        }

        private static IEnumerable<TestCaseData> DataSourceConsignacion()
        {
            yield return new TestCaseData("0101", "Cuenta #1", 100000, 100000).SetName("Consignacion de 100000");
            yield return new TestCaseData("0101", "Cuenta #2", 200000, 200000).SetName("Consignacion de 200000");
            yield return new TestCaseData("0101", "Cuenta #3", 300000, 300000).SetName("Consignacion de 300000");
            yield return new TestCaseData("0101", "Cuenta #4", 400000, 400000).SetName("Consignacion de 400000");
        }

        [Test]
        public void RetirarCuentaDeAhorroTest()
        {
            var cuenta = new CuentaBancariaFactory().Create("Ahorro");
            cuenta.Numero = "111";
            cuenta.Nombre = "Ahorro Ejemplo";
            cuenta.Ciudad = "Valledupar";
            cuenta.Consignar(new Transaccion(50000, "Valledupar"));
            cuenta.Retirar(new Transaccion(30000, "Valledupar"));
            Assert.AreEqual(20000, cuenta.Saldo);
        }


    }
}