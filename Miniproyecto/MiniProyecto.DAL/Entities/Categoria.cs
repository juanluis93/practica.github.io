﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.DAL.Entities
{
    public class Categoria
    {
        [Key]
        public int IDcategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual Series Series { get; set; }

    }
}
