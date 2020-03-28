using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Factory
{
    public class DepositoFactory
    {
        public Deposito Create(string tipoCuenta)
        {
            Deposito depositoNuevo = null;
            switch (tipoCuenta)
            {
                case "CDT":
                    depositoNuevo = new CDT();
                    break;
            }
            return depositoNuevo;
        }
    }
}
