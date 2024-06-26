using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public abstract class PedidoDto : IValidable, IIdentityById
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public ClienteDto ClienteDto { get; set; }
        public List<LineaPedidoDto> LineaPedidosDto { get; set; } 
        public DateTime FechaEntrega { get; set; }
        public int ClienteId { get; set; }
        public bool EstaAnulado { get; set; }
        public double SubTotal { get; set; }
        public double Impuestos { get; set; }
        public double Recargo { get; set; }
        public double Total { get; set; }

        public void Validar()
        {
            if (FechaPedido > DateTime.Today) { throw new Exception("La fecha no puede ser posterior al dia actual"); }
            if (FechaEntrega == DateTime.MinValue) { throw new Exception("Debe ingresar una fecha de entrega"); }
            if (FechaEntrega < DateTime.Today) { throw new Exception("La fecha de entrega no puede ser una fecha en el pasado"); }

        }

        public abstract double CalcularRecargo(double subtotal);

        public virtual void CalcularTotal(double iva)
        {
            double total = 0;
            double impuestos = 0;
            double recargo = 0;
            double subTotal = 0;

            foreach (LineaPedidoDto lineaPedido in LineaPedidosDto)
            {
                subTotal += lineaPedido.CalcularSubTotal();
                recargo += CalcularRecargo(subTotal);
                impuestos += CalcularIVA(iva, subTotal);
                total += subTotal + recargo + impuestos;
            }

            SubTotal = subTotal;
            Impuestos = impuestos;
            Recargo = recargo;
            Total = total;
        }

        public virtual double CalcularIVA(double iva, double subtotal)
        {
            return subtotal * (iva / 100); //Porque siempre vamos a estar hablando de %
        }

        public void AnularPedido()
        {
            EstaAnulado = true;
        }
    }
}
