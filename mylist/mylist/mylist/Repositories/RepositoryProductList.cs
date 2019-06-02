using mylist.Models;
using mylist.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mylist.Repositories
{
    public class RepositoryProductList
    {
        ApiConnect connect;
        public RepositoryProductList()
        {
            this.connect = new ApiConnect();
        }

        public async Task<List<ProductList>> GetListaUsuario(int idUsuario)
        {
            List<ProductList> lista =  await this.connect.CallApi<List<ProductList>>("api/ProductList/GetListas/" + idUsuario, null);
            return lista;
        }
        public async Task<ProductList> GetLista(int id)
        {
            ProductList productList = await this.connect.CallApi<ProductList>("api/ProductList/GetLista/" + id, null);
            return productList;
        }

        public async Task CrearLista(ProductList productList, int idUsuario)
        {
            await this.connect.CallApiPost(productList, "api/ProductList/CrearLista/" + idUsuario, null);
        }

        public async Task ModificarLista(ProductList productList)
        {
            await this.connect.CallApiPost(productList, "api/ProductList/ModificarLista", null);
        }

        public async Task EliminarLista(int id)
        {
            await this.connect.CallApiPost(id, "api/ProductList/EliminarLista", null);
        }

    }
}
