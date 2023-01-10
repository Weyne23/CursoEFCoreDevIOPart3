﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DominandoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsultarDepartamentos();
            //DadosSensiveis();
            //HabilitarBatchSize();
            TempoComandoGeral();
        }

        static void TempoComandoGeral()
        {
            using var db = new Curso.Data.ApplicationContext();
            db.Database.ExecuteSqlRaw("WAITFOR DELAY '00:00:07'; SELECT 1");
        }

        static void HabilitarBatchSize()
        {
            using var db = new Curso.Data.ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            for (int i = 0; i < 50; i++)
            {
                db.Departamentos.Add(
                    new Curso.Domain.Departamento
                    {
                        Descricao = "Departamento " + i
                    }
                );
            }

            db.SaveChanges();
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
