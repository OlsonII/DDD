using Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Test
{
    public class CDTTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConsignarDepositoTest()
        {
            var cdt = new CDT();
            cdt.Numero = "111";
            cdt.Nombre = "Ahorro Ejemplo";
            cdt.Periodo = 5;
            cdt.TasaInteres = 0.06;
            cdt.Consignar(1000000, "Valledupar");
            Assert.AreEqual(1000000, cdt.Saldo);
        }

        [Test]
        public void TransferirDepositoTest()
        {
            var cdt = new CDT();
            cdt.Numero = "111";
            cdt.Nombre = "Ahorro Ejemplo";
            cdt.Periodo = 5;
            cdt.TasaInteres = 0.06;
            cdt.Consignar(1000000, "Valledupar");
            cdt.Trasladar(new CuentaAhorro(), 1000000, "Valledupar");
            Assert.AreEqual(0, cdt.Saldo);
        }

        [Test]
        public void RetirarDepositoTest()
        {
            var cdt = new CDT();
            cdt.Numero = "111";
            cdt.Nombre = "Ahorro Ejemplo";
            cdt.Periodo = 5;
            cdt.TasaInteres = 0.06;
            cdt.Consignar(1000000, "Valledupar");
            cdt.Retirar(1000000);
            Assert.AreEqual(0, cdt.Saldo);
        }
    }
}
