using Domain.Contracts;
using Domain.Entities;
using Domain.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CrearDepositoService
    {
        readonly IUnitOfWork _unitOfWork;
        
        public CrearDepositoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearDepositoResponse Ejecutar(CrearDepositoRequest request)
        {
            Deposito nuevoDeposito = null;
            Deposito deposito = _unitOfWork.DepositoRepository.FindFirstOrDefault(t => t.Numero == request.Numero);
            if (deposito == null)
            {
                nuevoDeposito = new DepositoFactory().Create(request.TipoCuenta);
                nuevoDeposito.Nombre = request.Nombre;
                nuevoDeposito.Numero = request.Numero;
                _unitOfWork.DepositoRepository.Add(nuevoDeposito);
                _unitOfWork.Commit();
                return new CrearDepositoResponse() { Mensaje = $"Se creó con exito la cuenta {nuevoDeposito.Numero}.", tipoDeDepositoCreado = request.TipoCuenta };
            }
            else
            {
                return new CrearDepositoResponse() { Mensaje = $"El número de cuenta ya exite" };
            }
        }
    }

    public class CrearDepositoRequest
    {
        public string Nombre { get; set; }
        public string TipoCuenta { get; set; }
        public string Numero { get; set; }
    }
    public class CrearDepositoResponse
    {
        public string Mensaje { get; set; }
        public string tipoDeDepositoCreado { get; set; }
    }
}
