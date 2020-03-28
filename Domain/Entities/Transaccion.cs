using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Transaccion
    {
        public double Valor { get; set; }
        public string Ciudad { get; set; }

        public Transaccion(double valor, string ciudad)
        {
            Valor = valor;
            Ciudad = ciudad;
        }

        public Transaccion(double valor)
        {
            Valor = valor;
        }
    }
}
