using ApiMyList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Data
{
    public class MyListContext : DbContext, IMyListContext
    {
        public MyListContext(DbContextOptions options): base(options) { }
        public DbSet<ProductList> Lists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<USER> Users { get; set; }
        public DbSet<Usuario_Lista> UsuarioLista { get; set; }
        public DbSet<Contactos> Contactos { get; set; }


        #region User
        public USER GetUser(string nick, string password)
        {
            String sql = "ML_GETUSUARIO @NICK,@PWD";
            SqlParameter pamNick = new SqlParameter("@NICK", nick);
            SqlParameter pamPWD = new SqlParameter("@PWD", password);
            return this.Users.FromSql(sql, pamNick, pamPWD).FirstOrDefault();
        }

        public void InsertUser(string nick, string password, string nombre, string apellido1, string apellido2, string email)
        {
            String sql = "ML_CREARUSUARIO @NICK,@PWD,@NOMBRE,@APELLIDO1,@APELLIDO2,@EMAIL";
            SqlParameter pamNick = new SqlParameter("@NICK", nick);
            SqlParameter pamPassword = new SqlParameter("@OWD", nick);
            SqlParameter pamNombre = new SqlParameter("@NOMBRE", nick);
            SqlParameter pamApellido1 = new SqlParameter("@APELLIDO1", nick);
            SqlParameter pamApellido2 = new SqlParameter("@APELLIDO2", nick);
            SqlParameter pamEmail = new SqlParameter("@EMAIL", nick);
            this.Database.ExecuteSqlCommand(sql, pamNick, pamPassword, pamNombre, pamApellido1, pamApellido2, pamEmail);
        }




        #endregion

    }
}
