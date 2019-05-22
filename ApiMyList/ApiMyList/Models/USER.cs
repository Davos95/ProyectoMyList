using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Models
{
    [Table("ML_USER")]
    public class USER
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column("NICK")]
        public String Nick { get; set; }
        [Column("PASSWORD")]
        public String Password { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("APELLIDO1")]
        public String Apellido1 { get; set; }
        [Column("APELLIDO2")]
        public String Apellido2 { get; set; }
        [Column("EMAIL")]
        public String Email { get; set; }
    }
}

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
     */
