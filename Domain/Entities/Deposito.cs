using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class Deposito : Entity<int>, IServicioFinanciero
    {
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public double Saldo { get; protected set; }
        public int Periodo { get; set; }
        public double TasaInteres { get; set; }

        public List<MovimientoFinanciero> Movimientos { get; set; }

        public Deposito()
        {
            Movimientos = new List<MovimientoFinanciero>();
        }

        public virtual void Consignar(Transaccion transaccion)
        {
            MovimientoFinanciero deposito = new MovimientoFinanciero();
            deposito.ValorConsignacion = transaccion.Valor;
            deposito.FechaMovimiento = DateTime.Now;
            Saldo += transaccion.Valor;
            Movimientos.Add(deposito);
        }
        public abstract void Retirar(Transaccion transaccion);

        public abstract void Trasladar(IServicioFinanciero servicioFinanciero, Transaccion transaccion);
    }
}
