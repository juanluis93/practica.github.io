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
    public class CategoriaRepository : ICategoria
    {
        private readonly MiniContext _context;

        public CategoriaRepository(MiniContext context, ILogger<Categoria> logger)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Categoria, bool>> filter)
        {
            return _context.Categoria.Any(filter);
        }

        public IEnumerable<Categoria> GetEntities()
        {
            return _context.Categoria.ToList();
        }

        public Categoria GetEntity(int entityid)
        {
            return _context.Categoria.Find(entityid);
        }

        public void Remove(Categoria entity)
        {
            _context.Categoria.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Categoria entity)
        {
            _context.Categoria.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Categoria entity)
        {
            try
            {
                Categoria categoriaModificar = GetEntity(entity.IDcategoria);
                categoriaModificar.IDcategoria = entity.IDcategoria;
                categoriaModificar.Nombre = entity.Nombre;
                categoriaModificar.Descripcion = entity.Descripcion;

                _context.Update(categoriaModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Manejar excepción
            }
        }
    }
}

