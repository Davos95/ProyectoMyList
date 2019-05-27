using ApiMyList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Repository
{
    public interface IRepositoryUser
    {
        void CrearUsuario(String Nick, String Password, String Nombre, String Apellido1, String Apellido2, String Email);
        List<USER> BuscarUsuario(String Nick);
        USER getUsuario(int id);
        void AgregarUsuario(int idUsuario, int idContacto);
        List<USER> GetContactos(int idUsuario);
    }
}
