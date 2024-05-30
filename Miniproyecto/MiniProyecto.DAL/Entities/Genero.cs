using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.DAL.Entities
{
    public class Genero
    {
        [Key]
        public int IDgenero { get; set; }
        public string Tipo { get; set; }
    }
}
