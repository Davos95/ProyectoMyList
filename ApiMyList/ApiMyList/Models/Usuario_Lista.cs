﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMyList.Models
{
    [Table("ML_LIST_USER")]
    public class Usuario_Lista
    {
        [Column("IDLISTA")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdLista { get; set; }
        [Column("IDUSER")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }
        [Column("ADMINISTRATOR")]
        public bool Administrador { get; set; }


    }
}
