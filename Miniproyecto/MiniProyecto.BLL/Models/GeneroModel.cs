using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Models
{
    public class GeneroModel
    {
        [Key]
        public int IDgenero { get; set; }
        public string Tipo { get; set; }


        public virtual ICollection<SeriesModel> Serie { get; set; }
    }
}
