using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.Responses.CategoriaResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Contracts
{
   public interface ICategoriaService : IBaseService
    {
        CategoriaRemoveResponses Remove(CategoriaDTO categoriaRemove);
        CategoriaSaveResponses Save(CategoriaDTO categoriaSave);
        CategoriaUpdateResponses Update(CategoriaDTO categoriaUpdate);

    }
}
