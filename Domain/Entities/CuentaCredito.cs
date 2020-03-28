using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CuentaCredito : CuentaBancaria
    {
        public double Deuda { get; protected set; }
        public CuentaCredito() 
        {
            Saldo = 1000000; 
        }       

        public override void Consignar(Transaccion transaccion)
        {
            if(transaccion.Valor > 0 && transaccion.Valor <= Deuda)
            {
                Deuda -= transaccion.Valor;
                base.Consignar(transaccion);
            }            
        }

        public override void Retirar(Transaccion transaccion)
        {
            if(transaccion.Valor > 0 && transaccion.Valor <= Saldo)
            {
                Deuda += transaccion.Valor;
                Saldo -= transaccion.Valor;
            }    
        }
    }
}
