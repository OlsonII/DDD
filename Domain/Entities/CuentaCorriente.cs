using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CuentaCorriente : CuentaBancaria
    {
        public const double SOBREGIRO = -1000;        

        public override void Consignar(double valor, string ciudad)
        {
            if (VerificarPrimeraConsignacion() && valor >= 100000)
            {
                base.Consignar(valor, ciudad);
            }
            else if(!VerificarPrimeraConsignacion())
            {
                base.Consignar(valor, ciudad);
            }
        }

        public override void Retirar(double valor)
        {
            double nuevoSaldo = Saldo - AplicarImpuesto(valor);
            if (nuevoSaldo >= SOBREGIRO)
            {
                MovimientoFinanciero movimiento = new MovimientoFinanciero();
                movimiento.ValorRetiro = AplicarImpuesto(valor);
                movimiento.FechaMovimiento = DateTime.Now;
                Saldo = nuevoSaldo;
                this.Movimientos.Add(movimiento);
            }
            else
            {
                throw new CuentaCorrienteRetirarMaximoSobregiroException("No es posible realizar el Retiro, supera el valor de sobregiro permitido");
            }
        }

        public bool VerificarPrimeraConsignacion()
        {
            if (Movimientos.Count == 0) return true;

            return false;
        }

        public double AplicarImpuesto(double valor)
        {
            return (valor + (valor*4 / 1000));
        }
    }

    [Serializable]
    public class CuentaCorrienteRetirarMaximoSobregiroException : Exception
    {
        public CuentaCorrienteRetirarMaximoSobregiroException() { }
        public CuentaCorrienteRetirarMaximoSobregiroException(string message) : base(message) { }
        public CuentaCorrienteRetirarMaximoSobregiroException(string message, Exception inner) : base(message, inner) { }
        protected CuentaCorrienteRetirarMaximoSobregiroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
