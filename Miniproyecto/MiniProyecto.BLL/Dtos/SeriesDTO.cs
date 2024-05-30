using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Dtos
{
    public class SeriesDTO
    {
        public int SerieID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string URL { get; set; }

        public int IDcategoria { get; set; }
        public CategoriaDTO Categoria { get; set; }

        public int IDproductor { get; set; }
        public ProductorDTO Productor { get; set; }

        public int IDgenero { get; set; }
        public int IDgenero2 { get; set; }
        public GeneroDTO Genero { get; set; }
    }
}
