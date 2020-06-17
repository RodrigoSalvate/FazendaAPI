using Dominio._1_Entidades.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio._0_Repositório
{
    public interface IRepositorioGenerico<Entidade> where Entidade : EntidadeBase
    {
        IEnumerable<Entidade> ObterPorId(object id);
        void Inserir(Entidade entidade);
        void Remover(Entidade entidade);
        void Remover(object id);
        void Update(Entidade entidade);
    }
}
