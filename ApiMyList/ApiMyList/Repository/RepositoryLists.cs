using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMyList.Data;
using ApiMyList.Models;

namespace ApiMyList.Repository
{
    public class RepositoryLists : IRepositoryLists
    {
        IMyListContext context;

        public RepositoryLists(IMyListContext context)
        {
            this.context = context;
        }

        public int GetNumListas()
        {
            var consulta = (from datos in context.Lists
                            select datos).Count();
            consulta += 1;
            return consulta;
        }

        public List<ProductList> GetListas(int idUsuario)
        {
            var consultaRelacionUsuarioLista = (from datos in context.UsuarioLista
                                                where datos.IdUsuario == idUsuario
                                                select datos.IdLista).ToList();

            var consultaListas = (from datos in context.Lists
                                  where consultaRelacionUsuarioLista.Contains(datos.Id)
                                  select datos).ToList();

            return consultaListas;
        }
        public ProductList GetLista(int id)
        {
            var consulta = from datos in context.Lists
                           where datos.Id == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void CrearLista(int id, string Nombre, string Descripcion, DateTime Fecha, float Presupuesto, bool ActivarLimite, float PresupuestoLimite, int idUsuario)
        {
            ProductList list = new ProductList();
            list.Id = this.GetNumListas();
            list.Nombre = Nombre;
            list.Descripcion = Descripcion;
            list.Fecha = Fecha;
            list.Presupuesto = Presupuesto;
            list.ActivarLimite = ActivarLimite;
            list.PresupuestoLimite = PresupuestoLimite;
            this.context.Lists.Add(list);
            this.context.SaveChanges();

            this.AddUsuarioLista(list.Id, idUsuario, true);
        }

        public void ModificarLista(int id, string Nombre, string Descripcion, DateTime Fecha, float Presupuesto, bool ActivarLimite, float PresupuestoLimite)
        {
            ProductList list = this.GetLista(id);
            list.Nombre = Nombre;
            list.Descripcion = Descripcion;
            list.Fecha = Fecha;
            list.Presupuesto = Presupuesto;
            list.ActivarLimite = ActivarLimite;
            list.Presupuesto = PresupuestoLimite;
            this.context.SaveChanges();
        }


        public void EliminarLista(int id)
        {
            ProductList lista = this.GetLista(id);
            this.context.Lists.Remove(lista);
            this.context.SaveChanges();
        }

        public void AddUsuarioLista(int idLista, int idUsuario, bool Administrador)
        {
            Usuario_Lista conexion = new Usuario_Lista();
            conexion.IdLista = idLista;
            conexion.IdUsuario = idUsuario;
            conexion.Administrador = Administrador;
            this.context.UsuarioLista.Add(conexion);
            this.context.SaveChanges();
        }

        public void DeleteUsuarioLista(int idLista, int idUsuario)
        {
            Usuario_Lista conexion = new Usuario_Lista();
            conexion.IdLista = idLista;
            conexion.IdUsuario = idUsuario;
            this.context.UsuarioLista.Remove(conexion);
            this.context.SaveChanges();
        }

    }
}
