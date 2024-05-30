using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Models
{
    public class SeriesModel
    {
        [Key]
        public int SerieID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string URL { get; set; }

        public int IDcategoria { get; set; }
        [ForeignKey("IDcategoria")]
        public virtual CategoriaModel Categoria { get; set; }

        public int IDproductor { get; set; }
        [ForeignKey("IDproductor")]
        public virtual ProductorModel Productor { get; set; }

        public int IDgenero { get; set; }
        [ForeignKey("IDgenero")]
        public int IDgenero2 { get; set; }
        [ForeignKey("IDgenero2")]

        public virtual GeneroModel Genero { get; set; }
    }
}
