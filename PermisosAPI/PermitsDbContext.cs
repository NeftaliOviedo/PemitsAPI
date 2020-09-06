using Microsoft.EntityFrameworkCore;
using PermisosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermisosAPI
{
    public class PermitsDbContext: DbContext
    {
        public PermitsDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Permit> Permit { get; set; }
        public DbSet<PermitType> PermitType { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelCreator)
        {
            new Permit.Map(modelCreator.Entity<Permit>());
        }
    }
}
