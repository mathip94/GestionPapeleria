using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PedidoComunDto : PedidoDto
    {
        public virtual void CalcularTotal(double iva)
        {
           base.CalcularTotal(iva);
        }

        public virtual double CalcularIVA(double iva, double subtotal)
        {
            return subtotal * (iva / 100); //Porque siempre vamos a estar hablando de %
        }

        public override double CalcularRecargo(double subtotal)
        {
            double recargo = 0;

            if (ClienteDto.DistanciaPapeleria > 100)
            {
                recargo = subtotal * 0.05;
            }

            return recargo;
        }
    }
}
