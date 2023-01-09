using System;
using System.Linq;

namespace DominandoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsultarDepartamentos();
            DadosSensiveis();
        }

        static void DadosSensiveis()
        {
            using var db = new Curso.Data.ApplicationContext();
            var descricao = "Departamento";
            var departamentos = db.Departamentos.Where(p => p.Descricao == descricao).ToArray();
        }

        static void ConsultarDepartamentos()
        {
            using var db = new Curso.Data.ApplicationContext();

            var departamentos = db.Departamentos.Where(p => p.Id > 0).ToArray();
        }
    }
}
