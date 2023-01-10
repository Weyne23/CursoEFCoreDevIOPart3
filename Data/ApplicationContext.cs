using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Curso.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly StreamWriter _writer = new StreamWriter("Meu_Log_Do_EF_Cote.txt", append: true);
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConection = "Data source=(localdb)\\mssqllocaldb;Initial Catalog=DevIO-02;Integrated Security=true;pooling=true"; //MultipleActiveResultSets=true
            //optionsBuilder.UseSqlServer(strConection, p => p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            optionsBuilder.UseSqlServer(strConection, p => p.MaxBatchSize(100))//MaxBatchSize pode aumentar ou diminuir o numero de inserções ao mesmo tempo
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            /*.LogTo(Console.WriteLine, new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted }, 
            LogLevel.Information,
            DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine);*/
            //.LogTo(_writer.WriteLine, LogLevel.Information);
            //.EnableDetailedErrors(); //Habilitar erros detalhados
            .EnableSensitiveDataLogging();
        }
        public override void Dispose()
        {
            base.Dispose();
            _writer.Dispose();
        }
    }

}