using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio._Util
{
    public class ParametrosBusca
    {
        const int TamanhoMaximoDaPagina = 50;
        public int NumeroDaPagina { get; set; } = 1;

        private int _TamanhoDaPagina = 10;

        public int TamanhoDaPagina
        {
            get
            {
                return _TamanhoDaPagina;
            }
            set
            {
                _TamanhoDaPagina = (value > TamanhoMaximoDaPagina) ? TamanhoMaximoDaPagina : value;
            }
        }
    }
}
