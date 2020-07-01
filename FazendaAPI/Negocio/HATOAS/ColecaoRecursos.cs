using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio.HATOAS
{
    public class ColecaoRecursos<T> : RecursoLink where T : RecursoLink
    {
        public ColecaoRecursos(List<T> valores)
        {
            Valores = valores;
        }

        public List<T> Valores { get; set; }

    }
}
