using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMyList.Data;
using ApiMyList.Models;
using ApiMyList.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMyList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        IRepositoryLists repo;

        public ProductListController(IRepositoryLists repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]/{idUsuario}")]
        public List<ProductList> GetListas(int idUsuario)
        {
            return this.repo.GetListas(idUsuario);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ProductList GetLista(int id)
        {
            return this.repo.GetLista(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void CrearLista(ProductList list, int idUsuario)
        {
            this.repo.CrearLista(list.Id, list.Nombre, list.Descripcion, list.Fecha, list.Presupuesto, list.ActivarLimite, list.PresupuestoLimite, idUsuario);
            
        }

        [HttpPost]
        [Route("[action]")]
        public void ModificarLista(ProductList list)
        {
            this.repo.ModificarLista(list.Id, list.Nombre, list.Descripcion, list.Fecha, list.Presupuesto, list.ActivarLimite, list.PresupuestoLimite);
        }

        [HttpPost]
        [Route("[action]")]
        public void EliminarLista(int id)
        {
            this.repo.EliminarLista(id);
        }

        [HttpPost]
        [Route("[action]")]
        public void InsertarUsuarioLista(Usuario_Lista usuarioLista)
        {

            this.repo.AddUsuarioLista(usuarioLista.IdLista, usuarioLista.IdUsuario, usuarioLista.Administrador);
        }

        [HttpPost]
        [Route("[action]")]
        public void EliminarUsuarioLista(Usuario_Lista usuarioLista)
        {
            this.repo.DeleteUsuarioLista(usuarioLista.IdLista, usuarioLista.IdUsuario);
        }


    }
}