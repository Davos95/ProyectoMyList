using ApiMyList.Data;
using ApiMyList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Repository
{
    
    public interface IRepositoryLists
    {
        int GetNumListas();
        List<ProductList> GetListas(int idUsuario);
        ProductList GetLista(int id);
        void CrearLista(int id, String Nombre, String Descripcion, DateTime Fecha, float Presupuesto, bool ActivarLimite, float PresupuestoLimite, int idUsuario);
        void ModificarLista(int id, String Nombre, String Descripcion, DateTime Fecha, float Presupuesto, bool ActivarLimite, float PresupuestoLimite);
        void EliminarLista(int id);
        void AddUsuarioLista(int idLista, int idUsuario, bool Administrador);
        void DeleteUsuarioLista(int idLista, int idUsuario);


    }
}
