using Domain.Contracts;
using Domain.Entities; //Verificar lo mismo
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class RetirarDepositoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RetirarDepositoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RetirarCDTResponse Ejecutar(RetirarCDTRequest request)
        {
            var CDT = _unitOfWork.DepositoRepository.FindFirstOrDefault(t => t.Numero == request.NumeroCDT);
            if (CDT != null)
            {
                CDT.Retirar(new Transaccion(request.Valor));
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
