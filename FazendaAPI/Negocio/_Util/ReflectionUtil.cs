
using System;
using System.Linq.Expressions;

namespace Negocio._Util
{
    public class ReflectionUtil
    {
        public static string ObterNomePropriedade<T>(Expression<Func<T>> expressao)
        {
            MemberExpression corpo = (MemberExpression)expressao.Body;

            return corpo.Member.Name;
        }
    }
}
