using Negocio.Validacao;
using System.Collections.Generic;

namespace Negocio.Serviço.Interface
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(object id);
        T Inserir(T Dto);
        void Remover(T Dto);
        void Remover(object id);
        T Atualizar(T Dto);
        List<RetornoValidacao> Validar(T Dto);
    }
}
