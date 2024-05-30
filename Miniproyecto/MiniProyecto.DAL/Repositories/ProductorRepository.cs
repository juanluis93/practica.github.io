using Microsoft.Extensions.Logging;
using MiniProyecto.DAL.Context;
using MiniProyecto.DAL.Entities;
using MiniProyecto.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.DAL.Repositories
{
    public class ProductorRepository : IProductor
    {
        private readonly MiniContext _context;

        public ProductorRepository(MiniContext context, ILogger<Productor> logger)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Productor, bool>> filter)
        {
            return _context.Productor.Any(filter);
        }

        public IEnumerable<Productor> GetEntities()
        {
            return _context.Productor.ToList();
        }

        public Productor GetEntity(int entityid)
        {
            return _context.Productor.Find(entityid);
        }

        public void Remove(Productor entity)
        {
            _context.Productor.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Productor entity)
        {
            _context.Productor.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Productor entity)
        {
            try
            {
                Productor productorModificar = GetEntity(entity.IDproductor);
                productorModificar.IDproductor = entity.IDproductor;
                productorModificar.Nombre = entity.Nombre;
                productorModificar.Empresa = entity.Empresa;

                _context.Update(productorModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Manejar excepción
            }
        }
    }
}
