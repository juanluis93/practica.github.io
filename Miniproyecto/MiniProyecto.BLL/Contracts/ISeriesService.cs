using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Responses.SerieResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Contracts
{
    public interface ISeriesService : IBaseService
    {
        SerieRemoveResponses Remove(SeriesDTO seriRemove);
        SerieSaveResponses Save(SeriesDTO seriSave);
        SerieUpdateResponses Update(SeriesDTO seriUpadate);
    }
}
