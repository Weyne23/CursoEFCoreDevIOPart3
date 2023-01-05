using System;
using System.Linq;

namespace DominandoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultarDepartamentos();
        }

        static void ConsultarDepartamentos()
        {
            using var db = new Curso.Data.ApplicationContext();

            var departamentos = db.Departamentos.Where(p => p.Id > 0).ToArray();
        }
    }
}
