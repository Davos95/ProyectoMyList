using ApiMyList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Data
{
    public interface IMyListContext
    {
        DbSet<ProductList> Lists { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<USER> Users { get; set; }
        DbSet<Usuario_Lista> UsuarioLista { get; set; }
        DbSet<Contactos> Contactos { get; set; }
        
        #region Users

        void InsertUser(String nick, String password, String nombre, String apellido1, String apellido2, String email);

        USER GetUser(String nick, String password);



        #endregion
        int SaveChanges();
    }
}

#region Procedures
/*
 
     CREATE PROCEDURE ML_CREARUSUARIO
(@NICK nvarchar(25), @PWD TEXT, @NOMBRE NVARCHAR(15), @APELLIDO1 NVARCHAR(25), @APELLIDO2 NVARCHAR(25), @EMAIL NVARCHAR(100))
AS
	BEGIN
		INSERT INTO ML_USER VALUES(@NICK,@PWD,@NOMBRE,@APELLIDO1,@APELLIDO2,@EMAIL);
	END
GO


CREATE PROCEDURE ML_GETUSUARIO
(@NICK NVARCHAR(25), @PWD TEXT)
AS
	SELECT * FROM ML_USER WHERE NICK LIKE @NICK AND PASSWORD LIKE @PWD;
GO
     

ALTER PROCEDURE ML_INSERTLIST
(@IDLISTA INT, @NOMBRE NVARCHAR(25), @DESCRIPCION NVARCHAR(60), @FECHA DATE, @PRESUPUESTO FLOAT, @ACTIVARLIMITE BIT, @PRESUPUESTOLIMITE FLOAT, @MEDIAPERSONA FLOAT, @IDUSER INT)
AS

	INSERT INTO ML_PRODUCTLIST VALUES (@IDLISTA,@NOMBRE,@DESCRIPCION,@FECHA,@PRESUPUESTO,@ACTIVARLIMITE,@PRESUPUESTOLIMITE,@MEDIAPERSONA);
	INSERT INTO ML_LIST_USER VALUES(@IDLISTA, @IDUSER, 1);
GO



*/
#endregion