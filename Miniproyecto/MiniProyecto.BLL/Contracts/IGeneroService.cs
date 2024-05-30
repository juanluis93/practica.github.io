using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Responses.GeneroResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Contracts
{
   public interface IGeneroService : IBaseService
    {
        GeneroRemoveResponses Remove(GeneroDTO generoRemove);
        GeneroSaveResponses Save(GeneroDTO generoSave);
        GeneroUpdateResponses Update(GeneroDTO generoUpdate);
    }
}
