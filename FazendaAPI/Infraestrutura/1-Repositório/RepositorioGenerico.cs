using Dominio._0_Repositório;
using Dominio._1_Entidades.Base;
using Infraestrutura._0_Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infraestrutura._1_Repositório
{
    public class RepositorioGenerico<Entidade> : IRepositorioGenerico<Entidade> where Entidade : EntidadeBase
    {
        internal SqlServerContext context;
        internal DbSet<Entidade> dbSet;

        public RepositorioGenerico(SqlServerContext _context)
        {
            context = _context;
            dbSet = context.Set<Entidade>();
        }

        public void Inserir(Entidade entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entidade> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Entidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(object id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Entidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}
