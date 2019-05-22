using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Models
{
    [Table("PRODUCT")]
    public class PRODUCT
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column("IDLISTA")]
        public int IdLista { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("CANTIDAD")]
        public int Cantidad { get; set; }
        [Column("PRECIO")]
        public float Precio { get; set; }
        [Column("CHECKED")]
        public bool Checked { get; set; }
    }
}
