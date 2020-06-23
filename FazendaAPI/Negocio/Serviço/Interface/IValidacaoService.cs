using Negocio.Validacao;
using System.Collections.Generic;

namespace Negocio.Serviço.Interface
{
    public interface IValidacaoService
    {
        bool TemErro { get; }

        List<RetornoValidacao> validacoes { get; set; }

        void ValidarVazioOuNulo(object propriedade, string nomePropriedade);
    }
}
