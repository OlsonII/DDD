using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{    
    public class CDT : Deposito
    {

        private const double MINIMODEPOSITO = 1000000;
        
        public override void Consignar(Transaccion transaccion)
        {
            if(transaccion.Valor >= MINIMODEPOSITO && Saldo == 0)
            {
                base.Consignar(transaccion);
            }
        }

        public override void Trasladar(IServicioFinanciero servicioFinanciero, Transaccion transaccion)
        {
            if (VerificarPeriodo() && Saldo > 0)
            {
                Retirar(transaccion);
                servicioFinanciero.Consignar(transaccion);
            }                
        }

        public override void Retirar(Transaccion transaccion)
        {
            if (VerificarPeriodo() && Saldo > 0)
            {
                MovimientoFinanciero retiro = new MovimientoFinanciero();
                retiro.ValorRetiro = transaccion.Valor + (transaccion.Valor*TasaInteres);
                retiro.FechaMovimiento = DateTime.Now;
                Saldo = 0;
                Movimientos.Add(retiro);
            }
        }

        private bool VerificarPeriodo()
        {
            /*var fechaDeposito = Movimientos[0].FechaMovimiento;
            var fechaActual = DateTime.Now;

            var diferencia = (fechaActual.Month - fechaDeposito.Month) + (12*(fechaActual.Year - fechaDeposito.Year));

            if (diferencia >= Periodo) return true;
            return false;*/
            return true;
        }

    }
}
