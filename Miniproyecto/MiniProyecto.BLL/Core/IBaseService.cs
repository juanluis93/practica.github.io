using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProyecto.BLL.Dtos;
using MiniProyecto.BLL.core;
namespace MiniProyecto.BLL.Dtos
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int Id);


    }
}
