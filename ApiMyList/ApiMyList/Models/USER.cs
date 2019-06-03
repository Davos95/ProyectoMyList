using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Models
{
    [Table("ML_USER")]
    public class USER
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


