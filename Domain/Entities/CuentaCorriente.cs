using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CuentaCorriente : CuentaBancaria
    {
        public const double SOBREGIRO = -100000;        

        public override void Consignar(Transaccion transaccion)
        {
            if (VerificarPrimeraConsignacion() && transaccion.Valor >= 100000)
            {
                base.Consignar(transaccion);
            }
            else if(!VerificarPrimeraConsignacion())
            {
                base.Consignar(transaccion);
            }
        }

        public override void Retirar(Transaccion transaccion)
        {
            double nuevoSaldo = Saldo - AplicarImpuesto(transaccion.Valor);
            if (nuevoSaldo >= SOBREGIRO)
            {
                MovimientoFinanciero movimiento = new MovimientoFinanciero();
                movimiento.ValorRetiro = AplicarImpuesto(transaccion.Valor);
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
