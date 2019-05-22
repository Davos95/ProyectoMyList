using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Models
{
    [Table("PRODUCTLIST")]
    public class LIST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NOMBRE")]
        public String Nombre { get; set; }
        [Column("DESCRIPCION")]
        public String Descripcion { get; set; }
        [Column("FECHA")]
        public DateTime Fecha { get; set; }
        [Column("PRESUPUESTO")]
        public float Presupuesto { get; set; }
        [Column("ACTIVARLIMITE")]
        public bool ActivarLimite { get; set; }
        [Column("PRESUPUESTOLIMITE")]
        public float PresupuestoLimite { get; set; }
        [Column("MEDIAPERSONA")]
        public float MediaPersona { get; set; }
    }
}
