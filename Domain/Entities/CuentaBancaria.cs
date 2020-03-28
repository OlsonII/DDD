using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class CuentaBancaria : Entity<int>, IServicioFinanciero
    {
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public double Saldo { get; protected set; }
        public string Ciudad { get; set; }

        public List<MovimientoFinanciero> Movimientos { get; set; }

        public CuentaBancaria()
        {
            Movimientos = new List<MovimientoFinanciero>();            
        }        
        
        public virtual void Consignar(Transaccion transaccion)
        {            
            MovimientoFinanciero movimiento = new MovimientoFinanciero();
            movimiento.ValorConsignacion = transaccion.Valor;
            movimiento.FechaMovimiento = DateTime.Now;
            Saldo += transaccion.Valor;
            Movimientos.Add(movimiento);
        }
        
        public abstract void Retirar(Transaccion transaccion);

        public override string ToString()
        {
            return ($"Su saldo disponible es {Saldo}.");
        }

        public void Trasladar(IServicioFinanciero servicioFinanciero, Transaccion transaccion)
        {
            Retirar(transaccion);
            servicioFinanciero.Consignar(transaccion);
        }
    }
}
