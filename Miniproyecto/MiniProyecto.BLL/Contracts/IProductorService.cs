using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Responses.ProductorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Contracts
{
    public interface IProductorService : IBaseService
    {
        ProductorRemoveResponses Remove(ProductorDTO productorRemove);
        ProductorSaveResponses Save(ProductorDTO productorSave);
        ProductorUpdateResponses Update(ProductorDTO productorUpdate);
    }
}
