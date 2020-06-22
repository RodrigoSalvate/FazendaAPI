using Dominio._0_Repositório;
using Dominio._1_Entidades.Base;
using Infraestrutura._0_Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public Entidade Inserir(Entidade entidade)
        {
            dbSet.Add(entidade);

            return entidade;
        }
        public void Remover(Entidade entidade)
        {
            dbSet.Remove(entidade);
        }

        public void Remover(object id)
        {
            Remover(dbSet.Find(id));
        }

        public Entidade Atualizar(Entidade entidade)
        {
            dbSet.Attach(entidade).State = EntityState.Modified;
            return entidade;
        }

        public IEnumerable<Entidade> ObterTodos()
        {
            return dbSet.ToList();
        }
    }
}
