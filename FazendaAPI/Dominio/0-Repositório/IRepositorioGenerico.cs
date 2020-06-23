using Dominio._1_Entidades.Base;
using Dominio._ListaPaginada;

namespace Dominio._0_Repositório
{
    public interface IRepositorioGenerico<T> where T : EntidadeBase
    {
        T Inserir(T entidade);
        void Remover(T entidade);
        void Remover(object id);
        T Atualizar(T entidade);
        ListaPaginada<T> ObterTodos(int numeroPagina, int tamanhoPagina);
    }
}
