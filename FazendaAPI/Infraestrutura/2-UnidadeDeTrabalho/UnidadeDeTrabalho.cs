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

        public UnidadeDeTrabalho()
        {
            contexto = new SqlServerContext();
        }
        public void Commit()
        {
            contexto.SaveChanges();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
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
