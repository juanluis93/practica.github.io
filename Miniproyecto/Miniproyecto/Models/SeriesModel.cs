namespace MiniProyecto.Web.Models
{
    public class SeriesModel
    {
        public int SerieID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string URL { get; set; }
       

        public int IDcategoria { get; set; }


        public int IDproductor { get; set; }

        public int IDgenero { get; set; }
        public int IDgenero2 { get; set; }
    }
}