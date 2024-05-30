using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MiniProyecto.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProyecto.DAL.Context
{
    public class MiniContext: DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Productor> Productor { get; set; }
        public DbSet<Series> Series { get; set; }

        public MiniContext(DbContextOptions<MiniContext> options): base(options) { }

    
    }
}
