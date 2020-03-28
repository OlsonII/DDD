using Domain.Contracts;
using Domain.Entities; //Verificar si Transaccion esta ubicada correctamente
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    class ConsignarDepositoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsignarDepositoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepositarResponse Ejecutar(DepositarRequest request)
        {
            var CDT = _unitOfWork.DepositoRepository.FindFirstOrDefault(t => t.Numero == request.NumeroDeDeposito);
            if(CDT != null)
            {
                CDT.Consignar(new Transaccion(request.Valor, request.Ciudad));
                _unitOfWork.Commit();
                return new DepositarResponse() { Mensaje = $"Su deposito es de ${CDT.Saldo}." };
            }
            else
            {
                return new DepositarResponse() { Mensaje = $"Número de CDT No Válido." };
            }

        }


    }

    public class DepositarRequest 
    {
        public string NumeroDeDeposito { get; set; }
        public double Valor { get; set; }

        public string Ciudad { get; set; }
    }

    public class DepositarResponse
    {
        public string Mensaje { get; set; }
    }
}
