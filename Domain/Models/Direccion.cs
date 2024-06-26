using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Direccion : IValidable, IIdentityById, ICopiable<Direccion>
    {
        public int Id { get; set; }    
        public string Calle {  get; set; }
        public string Numero { get; set; }
        public string Ciudad { get; set; }

        public void Copy(Direccion model)
        {
            Calle = model.Calle;
            Numero = model.Numero;
            Ciudad = model.Ciudad;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Calle)) { throw new Exception("Debe ingresar una calle"); }

            if (string.IsNullOrEmpty(Numero)) { throw new Exception("Debe ingresar un numero"); }

            if (string.IsNullOrEmpty(Ciudad)) { throw new Exception("Debe ingresar una ciudad"); }
        }
    }
}
