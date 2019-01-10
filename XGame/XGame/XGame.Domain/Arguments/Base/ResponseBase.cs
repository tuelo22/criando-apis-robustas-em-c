using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Domain.Arguments.Base
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = XGame.Domain.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }
        public string Message { get; set; }
    }
}
