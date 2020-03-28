using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class CuentaAhorro : CuentaBancaria
    {
        private const double _TOPERETIRO = 20000;
        private const double _COSTORETIRO = 5000;

        public override void Consignar(Transaccion transaccion)
        {
            if (VerificarPrimeraConsignacion() && transaccion.Valor >= 50000)
            {
                base.Consignar(transaccion);
            }
            else if(!VerificarPrimeraConsignacion() && transaccion.Valor >= 0)
            {
                if (!Ciudad.Equals(transaccion.Ciudad)) transaccion.Valor -= 10000;
                base.Consignar(transaccion);
            }
        }

        public override void Retirar(Transaccion transaccion)
        {
            if (!ValidarRetirosDelMes()) transaccion.Valor += _COSTORETIRO;
            double nuevoSaldo = Saldo - transaccion.Valor;
            if (nuevoSaldo >= _TOPERETIRO)
            {                
                MovimientoFinanciero retiro = new MovimientoFinanciero();
                retiro.ValorRetiro = transaccion.Valor;
                retiro.FechaMovimiento = DateTime.Now;
                Saldo -= transaccion.Valor;
                this.Movimientos.Add(retiro);
            }
            else
            {
                throw new CuentaAhorroTopeDeRetiroException("No es posible realizar el Retiro, Supera el tope mínimo permitido de retiro");
            }
        }

        private bool ValidarRetirosDelMes()
        {
            string mesActual = DateTime.Now.Month + "/" + DateTime.Now.Year;
            int contador = 0;
            for(int i = 0; i<Movimientos.Count; i++)
            {
                string mesMovimiento = Movimientos[i].FechaMovimiento.Month + "/" + Movimientos[i].FechaMovimiento.Year;
                if (mesActual.Equals(mesMovimiento))
                {
                    contador++;
                }
            }
            if (contador < 3) return true;
            return false;
        }

        private bool VerificarPrimeraConsignacion()
        {
            if (Movimientos.Count != 0) return false;
            return true;
        }
    }


    [Serializable]
    public class CuentaAhorroTopeDeRetiroException : Exception
    {
        public CuentaAhorroTopeDeRetiroException() { }
        public CuentaAhorroTopeDeRetiroException(string message) : base(message) { }
        public CuentaAhorroTopeDeRetiroException(string message, Exception inner) : base(message, inner) { }
        protected CuentaAhorroTopeDeRetiroException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
