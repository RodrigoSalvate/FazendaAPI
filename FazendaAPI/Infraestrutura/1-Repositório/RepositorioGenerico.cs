using Dominio._0_Repositório;
using Dominio._1_Entidades.Base;
using Dominio._ListaPaginada;
using Infraestrutura._0_Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura._1_Repositório
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : EntidadeBase
    {
        internal SqlServerContext context;
        internal DbSet<T> dbSet;

        public RepositorioGenerico(SqlServerContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        public T Inserir(T entidade)
        {
            dbSet.Add(entidade);

            return entidade;
        }
        public void Remover(T entidade)
        {
            dbSet.Remove(entidade);
        }

        public void Remover(object id)
        {
            Remover(dbSet.Find(id));
        }

        public T Atualizar(T entidade)
        {
            dbSet.Attach(entidade).State = EntityState.Modified;
            return entidade;
        }

        public ListaPaginada<T> ObterTodos(int numeroPagina, int tamanhoPagina)
        {
            return ListaPaginada<T>.PaginarLista(dbSet, numeroPagina, tamanhoPagina);
        }
    }
}
