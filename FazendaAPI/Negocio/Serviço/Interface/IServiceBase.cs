using Negocio._Util;
using Negocio.Validacao;
using System.Collections.Generic;

namespace Negocio.Serviço.Interface
{
    public interface IServiceBase<T> where T : class
    {
        IEnumerable<T> ObterTodos(ParametrosBusca parametrosBusca);
        T Inserir(T Dto);
        void Remover(T Dto);
        void Remover(object id);
        T Atualizar(T Dto);
        List<RetornoValidacao> Validar(T Dto);
    }
}
