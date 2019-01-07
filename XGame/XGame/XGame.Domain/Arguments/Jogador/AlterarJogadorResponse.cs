using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Message { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador entidade)
        {
            return new AlterarJogadorResponse() {
                Email = entidade.Email.Endereco,
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
