using Dominio._1_Entidades.Base;
using System.Collections.Generic;

namespace Dominio._0_Repositório
{
    public interface IRepositorioGenerico<Entidade> where Entidade : EntidadeBase
    {
        Entidade Inserir(Entidade entidade);
        void Remover(Entidade entidade);
        void Remover(object id);
        Entidade Atualizar(Entidade entidade);
        IEnumerable<Entidade> ObterTodos();
    }
}
