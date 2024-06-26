using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cliente : IValidable, IIdentityById, ICopiable<Cliente>
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }    
        public string Rut {  get; set; }
        public Direccion Direccion { get; set; }
        public double DistanciaPapeleria { get; set; }

        public int DireccionId { get; set; }

        public void Copy(Cliente model)
        {
            RazonSocial = model.RazonSocial;
            Rut = model.Rut;
            Direccion = model.Direccion;
            DistanciaPapeleria = model.DistanciaPapeleria;
        }

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

            if (Direccion == null)
            {
                throw new Exception("El cliente debe tener una direccion");
            }

            Direccion.Validar();
        }
    }
}
