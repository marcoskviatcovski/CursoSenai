using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class EFContext : DbContext
    {
        public EFContext() : base("EFConnectionString")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Usuario> EUsuarios { get; set; }


    }
}