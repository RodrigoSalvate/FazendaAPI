using Dominio._1_Entidades.Base;
using Dominio._ListaPaginada;
using System;

namespace Dominio._0_Repositório
{
    public interface IRepositorioGenerico<T> where T : EntidadeBase
    {
        T Inserir(T entidade);
        void Remover(T entidade);
        void Remover(Guid id);
        T Atualizar(T entidade);
        ListaPaginada<T> ObterTodos(int numeroPagina, int tamanhoPagina);
        T ObterPorId(Guid id);
    }
}
