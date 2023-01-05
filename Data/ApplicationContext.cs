using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;

namespace Curso.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConection = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=DevIO-02;Integrated Security=true;pooling=true"; //MultipleActiveResultSets=true
            //optionsBuilder.UseSqlServer(strConection, p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            optionsBuilder.UseSqlServer(strConection)
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }
}