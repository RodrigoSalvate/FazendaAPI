using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testes._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ArgumentException exception, string message)
        {
            if (exception.Message.Equals(message))
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"Mensagem esperada: {exception.Message}");
            }
        }
    }
}
