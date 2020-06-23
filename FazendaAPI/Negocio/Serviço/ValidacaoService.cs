using Negocio.Serviço.Interface;
using Negocio.Validacao;
using System.Collections.Generic;
namespace Negocio.Serviço
{
    public class ValidacaoService : IValidacaoService
    {
        public bool TemErro
        {
            get
            {
                return validacoes.Count > 0;
            }
        }

        public ValidacaoService()
        {
            validacoes = new List<RetornoValidacao>();
        }

        /// <summary>
        /// Lista com os campos obrigatórios não informados.
        /// </summary>
        public List<RetornoValidacao> validacoes { get; set; }

        /// <summary>
        /// Valida o preenchimento obrigatório da propriedade informada
        /// </summary>
        /// <param name="propriedade"></param>
        public void ValidarVazioOuNulo(object propriedade, string nomePropriedade)
        {
            if (propriedade == null)
            {
                AdicionarMensagem(nomePropriedade);
            }
            else if (propriedade.GetType() == typeof(string) && string.IsNullOrEmpty((string)propriedade))
            {
                AdicionarMensagem(nomePropriedade);
            }
            else if ((propriedade.GetType() == typeof(double) || propriedade.GetType() == typeof(int)) && (double)propriedade <= 0)
            {
                AdicionarMensagem(nomePropriedade);
            }
        }

        private void AdicionarMensagem(string nomePropriedade)
        {
            validacoes.Add(new RetornoValidacao() { Campo = nomePropriedade, Mensagem = "Campo obrigatório não informado." });
        }
    }
}
