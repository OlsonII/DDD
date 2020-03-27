using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RetirarInversionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RetirarInversionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RetirarCDTResponse Ejecutar(RetirarCDTRequest request)
        {
            var CDT = _unitOfWork.CDTRepository.FindFirstOrDefault(t => t.Numero == request.NumeroCDT);
            if (CDT != null)
            {
                CDT.Retirar(request.Valor);
                _unitOfWork.Commit();
                return new RetirarCDTResponse() { Mensaje = $"Su deposito es de ${CDT.Saldo}." };
            }
            else
            {
                return new RetirarCDTResponse() { Mensaje = $"Número de CDT No Válido." };
            }
        }
        
    }

    public class RetirarCDTRequest
    {
        public string NumeroCDT { get; set; }
        public double Valor { get; set; }
    }

    public class RetirarCDTResponse
    {
        public string Mensaje { get; set; }
    }
}
