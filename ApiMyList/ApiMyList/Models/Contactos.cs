using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Models
{
    [Table("ML_CONTACTS")]
    public class Contactos
    {
        [Column("IDUSUARIO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }
        [Column("IDCONTACTO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdContacto { get; set; }
    }
}
