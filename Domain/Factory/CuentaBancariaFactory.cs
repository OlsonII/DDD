using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Factory
{
    public class CuentaBancariaFactory
    {
        public CuentaBancaria Create(string tipoCuenta)
        {
            CuentaBancaria cuentaNueva = null;
            switch (tipoCuenta)
            {
                case "Ahorro":
                    cuentaNueva = new CuentaAhorro();
                    break;
                case "Corriente":
                    cuentaNueva = new CuentaCorriente();
                    break;
                case "Credito":
                    cuentaNueva = new CuentaCredito();
                    break;
            }
            return cuentaNueva;
        }
    }
}
