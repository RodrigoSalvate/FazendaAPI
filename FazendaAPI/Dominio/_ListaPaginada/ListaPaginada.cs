using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio._ListaPaginada
{
    public class ListaPaginada<T> : List<T>
    {
        public int PaginaAtual { get; private set; }
        public int TotalDePaginas { get; private set; }
        public int TamanhoDaPagina { get; private set; }
        public int ContagemTotalDeItems { get; private set; }

        public bool TemPaginaAnterior => PaginaAtual > 1;
        public bool TemProximaPagina => PaginaAtual < TotalDePaginas;

        public ListaPaginada(List<T> items, int totalDeItens, int numeroDaPagina, int tamanhoDaPagina)
        {
            ContagemTotalDeItems = totalDeItens;
            TamanhoDaPagina = tamanhoDaPagina;
            PaginaAtual = numeroDaPagina;
            TotalDePaginas = (int)Math.Ceiling(totalDeItens / (double)tamanhoDaPagina);

            AddRange(items);
        }

        public static ListaPaginada<T> PaginarLista(IQueryable<T> origem, int numeroDaPagina, int tamanhoDaPagina)
        {
            var totalDeItems = origem.Count();
            var items = origem.Skip((numeroDaPagina - 1) * tamanhoDaPagina).Take(tamanhoDaPagina).ToList();

            return new ListaPaginada<T>(items, totalDeItems, numeroDaPagina, tamanhoDaPagina);
        }
    }
}
