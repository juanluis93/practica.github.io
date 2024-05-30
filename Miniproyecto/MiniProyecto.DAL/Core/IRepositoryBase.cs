using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.BLL.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Remove(TEntity entity);
        void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetEntity(int entityid);
        bool Exists(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetEntities();
    }
}
