using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class Pedido : IValidable, IIdentityById, ICopiable<Pedido>
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; } = DateTime.Today;
        public Cliente Cliente { get; set; }
        public List<LineaPedido> LineaPedidos { get; set; } = new List<LineaPedido>();
        public DateTime FechaEntrega { get; set; }
        public bool EstaAnulado { get; set; }
        public int ClienteId { get; set; }
        public double SubTotal { get; set; }
        public double Impuestos { get; set; }
        public double Recargo { get; set; }
        public double Total { get; set; }

        // hay que agregar una fecha prometida de entrega? Parametro tambien podria ser una fecha estipulada de entrega? En ese caso habria que cambiar a Parametro iva y agregar Parametro fechaEstipuladaEntrega

        public void Copy(Pedido model)
        {
            FechaPedido = model.FechaPedido;
            Cliente = model.Cliente;
            LineaPedidos = model.LineaPedidos;
            FechaEntrega = model.FechaEntrega;
            EstaAnulado = model.EstaAnulado;
        }

        public void Validar()
        {
            if (FechaPedido > DateTime.Today) { throw new Exception("La fecha no puede ser posterior al dia actual"); }
            if (FechaEntrega == DateTime.MinValue) { throw new Exception("Debe ingresar una fecha de entrega"); }
            if (FechaEntrega < DateTime.Today) { throw new Exception("La fecha de entrega no puede ser una fecha en el pasado"); }
            if (Cliente == null) { throw new Exception("El pedido debe pertenecer a un cliente"); }
            if (LineaPedidos.Count == 0) { throw new Exception("No se puede crear una factura vacia"); }

            Cliente.Validar();
        }

        public abstract double CalcularRecargo(double subtotal);

        public virtual void CalcularTotal(double iva)
        {
            double total = 0;
            double impuestos = 0;
            double recargo = 0;
            double subTotal = 0;

            foreach (LineaPedido lineaPedido in LineaPedidos)
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
