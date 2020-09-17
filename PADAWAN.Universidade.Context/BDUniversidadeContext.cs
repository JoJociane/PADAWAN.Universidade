using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace PADAWAN.Universidade.Context
{
     public class BDUniversidadeContext : DbContext
    {
        public BDUniversidadeContext() 
        {

        }

        public BDUniversidadeContext(DbContextOptions<BDUniversidadeContext> options) :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BDUniversidadeContext).Assembly);
        }

    }
}
