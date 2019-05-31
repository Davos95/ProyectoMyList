using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMyList.Models;
using ApiMyList.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMyList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IRepositoryProducts repo;
        public ProductController(IRepositoryProducts repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public List<Product> GetProducts(int id)
        {
            return this.repo.GetProductos(id);
        }


        [HttpGet]
        [Route("[action]/{id}")]
        public Product GetProduct(int id)
        {
            return this.repo.GetProducto(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void InsertarProducto(Product product)
        {
            this.repo.InsertarProducto(product.IdLista, product.Nombre, product.Cantidad, product.Precio, product.Checked);
        }

        [HttpPost]
        [Route("[action]")]
        public void ModificarProducto(Product product)
        {
            this.repo.ModificarProducto(product.Id, product.IdLista, product.Nombre, product.Cantidad, product.Precio, product.Checked);
        }

        [HttpPost]
        [Route("[action]")]
        public void EliminarProducto(Product product)
        {
            this.repo.EliminarProducto(product.Id, product.IdLista);
        }

    }
}