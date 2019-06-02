using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mylist.Models
{

    public class Product
    {

        public int Id { get; set; }
        public int IdLista { get; set; }
        public String Nombre { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public bool Checked { get; set; }
    }
}
