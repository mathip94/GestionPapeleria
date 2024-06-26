using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PedidoComun : Pedido, IValidable, ICopiable<PedidoComun>
    {
        public override double CalcularRecargo(double subtotal)
        {
            double recargo = 0;

            if(Cliente.DistanciaPapeleria > 100)
            {
                recargo = subtotal * 0.05;
            }

            return recargo;
        }

        public override double CalcularIVA(double iva, double subtotal)
        {
            return base.CalcularIVA(iva, subtotal);
        }

        public override void CalcularTotal(double iva)
        {
            base.CalcularTotal(iva);
        }

        public void Validar()
        {
            TimeSpan diferenciaDiasParaEntrega = FechaEntrega - FechaPedido;
            int diasParaEntrega = diferenciaDiasParaEntrega.Days;
            if (diasParaEntrega < 7) { throw new Exception("Un pedido comun no puede demorar menos de 7 dias en ser entregado"); }
            base.Validar();
        }

        public void Copy(PedidoComun model)
        {
            FechaPedido = model.FechaPedido;
            Cliente = model.Cliente;
            LineaPedidos = model.LineaPedidos;
            FechaEntrega = model.FechaEntrega;
            EstaAnulado = model.EstaAnulado;
        }
    }
}
