using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProyecto.BLL.Models;
namespace MiniProyecto.BLL.Models
{
    public class CategoriaModel
    {
        [Key]
        public int IDcategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<SeriesModel> Serie { get; set; }
    }
}
