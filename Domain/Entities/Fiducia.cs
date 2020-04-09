using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Fiducia : Deposito
    {
        public override void Retirar(Transaccion transaccion)
        {
            throw new NotImplementedException();
        }

        public override void Trasladar(IServicioFinanciero servicioFinanciero, Transaccion transaccion)
        {
            throw new NotImplementedException();
        }
    }
}
