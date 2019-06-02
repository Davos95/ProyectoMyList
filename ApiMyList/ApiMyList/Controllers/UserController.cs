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
    public class UserController : ControllerBase
    {

        IRepositoryUser repo;
        public UserController( IRepositoryUser repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public void CrearUsuario(USER usuario)
        {
            this.repo.CrearUsuario(usuario.Nick,usuario.Password,usuario.Nombre,usuario.Apellido1,usuario.Apellido2,usuario.Email);
        }

        [HttpPost]
        [Route("[action]")]
        public void AgregarContacto(Contactos contacto)
        {
            this.repo.AgregarUsuario(contacto.IdUsuario, contacto.IdContacto);
            
        }


        [HttpGet]
        [Route("[action]/{idUsuario}")]
        public USER GetUsuario(int idUsuario)
        {
            return this.repo.getUsuario(idUsuario);
            
        }
        [HttpGet]
        [Route("[action]/{Nick}/{Password}")]
        public USER GetUsuarioCredenciales(String Nick, String Password)
        {
            return this.repo.ExisteUsuario(Nick, Password);
        }


        [HttpGet]
        [Route("[action]/{nick}")]
        public List<USER> BuscarUsuario(String nick)
        {
            return this.repo.BuscarUsuario(nick);
        }


    }
}