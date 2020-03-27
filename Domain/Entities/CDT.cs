using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{    
    public class CDT : Deposito
    {

        private const double MINIMODEPOSITO = 1000000;
        
        public override void Consignar(double valor, string ciudad)
        {
            if(valor >= MINIMODEPOSITO && Saldo == 0)
            {
                base.Consignar(valor, ciudad);
            }
        }

        public override void Trasladar(IServicioFinanciero servicioFinanciero, double valor, string ciudad)
        {
            if (VerificarPeriodo() && Saldo > 0)
            {
                Retirar(valor);
                servicioFinanciero.Consignar(valor, ciudad);
            }                
        }

        public override void Retirar(double valor)
        {
            if (VerificarPeriodo() && Saldo > 0)
            {
                MovimientoFinanciero retiro = new MovimientoFinanciero();
                retiro.ValorRetiro = valor += valor*TasaInteres;
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
