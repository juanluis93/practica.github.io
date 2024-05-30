using Microsoft.EntityFrameworkCore;
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

namespace Registro.DAL.Repositories
{
    public class GeneroRepository : IGenero
    {
        private readonly MiniContext _context;

        public GeneroRepository(MiniContext context, ILogger<Genero> logger)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Genero, bool>> filter)
        {
            return _context.Genero.Any(filter);
        }

        public IEnumerable<Genero> GetEntities()
        {
            return _context.Genero.ToList();
        }

        public Genero GetEntity(int entityid)
        {
            return _context.Genero.Find(entityid);
        }

        public void Remove(Genero entity)
        {
            _context.Genero.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Genero entity)
        {
            _context.Genero.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Genero entity)
        {
            try
            {
                Genero generoModificar = GetEntity(entity.IDgenero);
                generoModificar.IDgenero = entity.IDgenero;
                generoModificar.Tipo = entity.Tipo;

                _context.Update(generoModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Manejar excepción
            }
        }
    }
}
