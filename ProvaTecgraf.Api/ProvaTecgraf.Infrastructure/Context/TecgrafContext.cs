using Microsoft.EntityFrameworkCore;
using ProvaTecgraf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Infrastructure.Context
{
    public class TecgrafContext : DbContext
    {
        public TecgrafContext(DbContextOptions<TecgrafContext> options) : base(options) { }

        public DbSet<Empregado> tblEmpregado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TecgrafContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
