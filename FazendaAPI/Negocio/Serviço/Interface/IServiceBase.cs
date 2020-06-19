using System.Collections.Generic;

namespace Negocio.Serviço.Interface
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> ObterTodos();
        T ObterPorId(object id);
        void Inserir(T Dto);
        void Remover(T Dto);
        void Remover(object id);
        void Atualizar(T Dto);
        void Validar(T Dto);
    }
}
