using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    interface IServicioInversion
    {
        string Nombre { get; set; }
        string Numero { get; set; }
        double Saldo { get; }

        void Depositar(double valor);
        void Retirar(double valor);
        
    }
}
