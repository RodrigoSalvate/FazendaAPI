using Dominio._0_Repositório;
using Dominio._1_Entidades;
using Infraestrutura._0_Context;
using Infraestrutura._1_Repositório;
using Infraestrutura._2_UnidadeDeTrabalho.Interface;
using System;

namespace Infraestrutura._2_UnidadeDeTrabalho
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho, IDisposable
    {
        private SqlServerContext contexto = null;
        private RepositorioGenerico<Animal> animalRepositorio = null;

        public UnidadeDeTrabalho(SqlServerContext _contexto)
        {
            contexto = _contexto;
        }
        public void Commit()
        {
            contexto.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    contexto.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepositorioGenerico<Animal> AnimalRepositorio
        {
            get
            {
                if (animalRepositorio == null)
                {
                    animalRepositorio = new RepositorioGenerico<Animal>(contexto);
                }

                return animalRepositorio;
            }
        }
    }
}
