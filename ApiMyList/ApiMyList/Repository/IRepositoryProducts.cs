using ApiMyList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Repository
{
    public interface IRepositoryProducts
    {
        List<Product> GetProductos(int idLista);
        Product GetProducto(int idProducto);
        void InsertarProducto(int IdLista, String Nombre, int Cantidad, float Precio, bool chekced);
        void EliminarProducto(int id, int IdLista);
        void ModificarProducto(int id, int IdLista, String Nombre, int Cantidad, float Precio, bool chekced);

        void check(int id, bool check);

    }
}
