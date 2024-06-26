using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PedidoExpress : Pedido, IValidable, ICopiable<PedidoExpress>
    {
        public override double CalcularIVA(double iva, double subtotal)
        {
            return base.CalcularIVA(iva, subtotal);
        }

        public override double CalcularRecargo(double subtotal)
        {
            double recargo = 0;

            // Recargo del 10% para pedidos express
            recargo = subtotal * 0.10;
            subtotal = recargo + subtotal;

            // Recargo adicional del 5% si la entrega es el mismo día
            if (FechaEntrega.Date == FechaEntrega.Date)
            {
                recargo += subtotal * 0.05;
            }

            return recargo;
        }

        public override void CalcularTotal(double iva)
        {
            base.CalcularTotal(iva);
        }

        public void Copy(PedidoExpress model)
        {
            FechaPedido = model.FechaPedido;
            Cliente = model.Cliente;
            LineaPedidos = model.LineaPedidos;
            FechaEntrega = model.FechaEntrega;
            EstaAnulado = model.EstaAnulado;
        }

        public void Validar()
        {
            TimeSpan diferenciaDiasParaEntrega = FechaEntrega - FechaPedido;
            int diasParaEntrega = diferenciaDiasParaEntrega.Days;
            if (diasParaEntrega > 5) { throw new Exception("Un pedido express no puede demorar mas de 5 dias en ser entregado"); }
            base.Validar();
        }
    }
}
