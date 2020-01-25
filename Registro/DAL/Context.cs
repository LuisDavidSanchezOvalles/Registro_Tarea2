using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Registro.Entidades;

namespace Registro.DAL
{
    public class Context : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = LUISDAVIDSO\SQLEXPRESS; Database = PersonasDb; Trusted_Connection = True");
        }
    }
}
