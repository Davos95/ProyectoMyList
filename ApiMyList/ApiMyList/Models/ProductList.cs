using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Models
{
    [Table("ML_PRODUCTLIST")]
    public class ProductList
    {
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("DESCRIPCION")]
        public String Descripcion { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("PRESUPUESTO")]
        public double Presupuesto { get; set; }
        [Column("ACTIVARLIMITE")]
        public bool ActivarLimite { get; set; }
        [Column("PRESUPUESTOLIMITE")]
        public double PresupuestoLimite { get; set; }

        [NotMapped]
        public int idUsuario { get; set; }
    }
}
