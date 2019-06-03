using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMyList.Data;
using ApiMyList.Models;

namespace ApiMyList.Repository
{
    public class RepositoryProducts : IRepositoryProducts
    {
        IMyListContext context;
        public RepositoryProducts(IMyListContext context)
        {
            this.context = context;
        }

        public List<Product> GetProductos(int idLista)
        {
            var consulta = (from datos in context.Products
                           where datos.IdLista == idLista
                           select datos).ToList();
            return consulta;
        }

        public Product GetProducto(int idProducto)
        {
            var consulta = from datos in context.Products
                           where datos.Id == idProducto
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertarProducto(int IdLista, string Nombre, int Cantidad, double Precio, bool chekced)
        {
            Product product = new Product();
            product.IdLista = IdLista;
            product.Nombre = Nombre;
            product.Cantidad = Cantidad;
            product.Precio = Precio;
            product.Checked = chekced;
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public void ModificarProducto(int id, int IdLista, string Nombre, int Cantidad, double Precio, bool chekced)
        {
            Product product = this.GetProducto(id);
            product.Nombre = Nombre;
            product.Cantidad = Cantidad;
            product.Precio = Precio;
            product.Checked = chekced;
            this.context.Products.Add(product);
            this.context.SaveChanges();
        }


        public void EliminarProducto(int id, int IdLista)
        {
            Product product = this.GetProducto(id);
            this.context.Products.Remove(product);
            this.context.SaveChanges();
        }

        public void check(int id, bool check)
        {
            Product product = this.GetProducto(id);
            product.Checked = check;
            this.context.SaveChanges();
        }
    }
}
