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

namespace MiniProyecto.DAL.Repositories
{
    public class SerieRepository : ISeries
    {
        private readonly MiniContext _context;

        public SerieRepository(MiniContext context, ILogger<Series> logger)
        {
            _context = context;
        }

        public bool Exists(Expression<Func<Series, bool>> filter)
        {
            return _context.Series.Any(filter);
        }

        public IEnumerable<Series> GetEntities()
        {
            return _context.Series
                .Include(s => s.Categoria)
                .Include(s => s.Productor)
                .Include(s => s.Genero)
                .Include(s=> s.Genero2)
                
                .ToList();
        }

        public Series GetEntity(int entityid)
        {
            return _context.Series
             .Include(s => s.Categoria)
                .Include(s => s.Productor)
                .Include(s => s.Genero)
                .Include(s => s.Genero2)
                .FirstOrDefault(s => s.SerieID == entityid);
        }

        public void Remove(Series entity)
        {
            _context.Series.Remove(entity);
            _context.SaveChanges();
        }

        public void Save(Series entity)
        {
            try
            {
                _context.Series.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Update(Series entity)
        {
            try
            {
                Series serieModificar = GetEntity(entity.SerieID);
                serieModificar.SerieID = entity.SerieID;
                serieModificar.Nombre = entity.Nombre;
                serieModificar.Descripcion = entity.Descripcion;
                serieModificar.Imagen = entity.Imagen;
                serieModificar.IDcategoria = entity.IDcategoria;
                serieModificar.IDproductor = entity.IDproductor;
                serieModificar.IDgenero = entity.IDgenero;
                serieModificar.IDgenero2 = entity.IDgenero2;
                serieModificar.URL = entity.URL;

                _context.Update(serieModificar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Manejar excepción
            }
        }
    }
}
