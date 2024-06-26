using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class ClienteDto : IValidable
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public DireccionDto DireccionDto { get; set; }
        public double DistanciaPapeleria { get; set; }

        public int DireccionId { get; set; }

        public void Validar()
        {
            if (Rut.Length != 12)
            {
                throw new Exception("El rut tiene que tener 12 caracteres");
            }

            if (string.IsNullOrEmpty(RazonSocial))
            {
                throw new Exception("Debe introducir una razon social");
            }

            if (DistanciaPapeleria == 0)
            {
                throw new Exception("Debe ingresar la distancia del cliente a la papeleria");
            }

            
        }
    }
}
