using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    class DepositarInversionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepositarInversionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DepositarResponse Ejecutar(DepositarRequest request)
        {
            var CDT = _unitOfWork.CDTRepository.FindFirstOrDefault(t => t.Numero == request.NumeroCDT);
            if(CDT != null)
            {
                CDT.Consignar(request.Valor, request.Ciudad);
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
        public string NumeroCDT { get; set; }
        public double Valor { get; set; }

        public string Ciudad { get; set; }
    }

    public class DepositarResponse
    {
        public string Mensaje { get; set; }
    }
}
