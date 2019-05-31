using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMyList.Data;
using ApiMyList.Models;

namespace ApiMyList.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        IMyListContext context;
        public RepositoryUser(IMyListContext context)
        {
            this.context = context;
        }

        public void AgregarUsuario(int idUsuario, int idContacto)
        {
            Contactos contactos = new Contactos();
            contactos.IdUsuario = idUsuario;
            contactos.IdContacto = idContacto;
            this.context.Contactos.Add(contactos);
            this.context.SaveChanges();
        }

        public List<USER> BuscarUsuario(string Nick)
        {
            var consulta = (from datos in context.Users
                            select datos).Where(x => x.Nick.Contains(Nick) ).ToList();
            return consulta;
        }

        public void CrearUsuario(string Nick, string Password, string Nombre, string Apellido1, string Apellido2, string Email)
        {
            USER user = new USER();
            user.Nick = Nick;
            user.Password = Password;
            user.Nombre = Nombre;
            user.Apellido1 = Apellido1;
            user.Apellido2 = Apellido2;
            user.Email = Email;
            this.context.Users.Add(user);
            this.context.SaveChanges();
        }

        public List<USER> GetContactos(int idUsuario)
        {
            var idContactos = (from datos in context.Contactos
                              where datos.IdUsuario == idUsuario
                              select datos.IdContacto).ToList();
            var usuarios = (from datos in context.Users
                            where idContactos.Contains(datos.Id)
                            select datos).ToList();
            return usuarios;
        }

        public USER getUsuario(int id)
        {
            var consulta = from datos in context.Users
                           where datos.Id == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public USER ExisteUsuario(String Nick, String Password)
        {
            var consulta = from datos in context.Users
                           where datos.Nick == Nick && datos.Password == Password
                           select datos;
            return consulta.FirstOrDefault();
        }
    }
}
