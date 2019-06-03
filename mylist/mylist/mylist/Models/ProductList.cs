using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace mylist.Models
{

    public class ProductList
    {

        public int Id { get; set; }

        public String Nombre { get; set; }

        public String Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public float Presupuesto { get; set; }

        public bool ActivarLimite { get; set; }

        public float PresupuestoLimite { get; set; }

        public float MediaPersona { get; set; }

        public int idUsuario { get; set; }
    }
}
