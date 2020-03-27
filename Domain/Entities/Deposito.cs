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

        public virtual void Consignar(double valor, string ciudad)
        {
            MovimientoFinanciero deposito = new MovimientoFinanciero();
            deposito.ValorConsignacion = valor;
            deposito.FechaMovimiento = DateTime.Now;
            Saldo += valor;
            Movimientos.Add(deposito);
        }
        public abstract void Retirar(double valor);

        public abstract void Trasladar(IServicioFinanciero servicioFinanciero, double valor, string ciudad);
    }
}
