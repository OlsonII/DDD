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

        public override void Consignar(double valor, string ciudad)
        {
            if(valor > 0 && valor <= Deuda)
            {
                Deuda -= valor;
                base.Consignar(valor, ciudad);
            }            
        }

        public override void Retirar(double valor)
        {
            if(valor > 0 && valor <= Saldo)
            {
                Deuda += valor;
                Saldo -= valor;
            }    
        }
    }
}
