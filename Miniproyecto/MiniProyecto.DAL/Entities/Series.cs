using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.DAL.Entities
{
    public class Series
    {
        [Key]
        public int SerieID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string URL { get; set; }


        public int IDcategoria { get; set; }
        [ForeignKey("IDcategoria")]
        public virtual Categoria Categoria { get; set; }

        public int IDproductor { get; set; }
        [ForeignKey("IDproductor")]
        public virtual Productor Productor { get; set; }

        public int IDgenero { get; set; }
        [ForeignKey("IDgenero")]
      
        public virtual Genero Genero { get; set; }
        public int IDgenero2 { get; set; }
        [ForeignKey("IDgenero2")] 
        public virtual Genero Genero2 { get; set; }
    }
}

