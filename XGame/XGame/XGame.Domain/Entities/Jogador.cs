using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Entities.Base;
using XGame.Domain.Enum;
using XGame.Domain.Extensions;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : EntityBase
    {
        protected Jogador()
        {
                
        }

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            new AddNotifications<Jogador>(this).IfNullOrInvalidLength(x => x.Senha, 6,32, "A senha deve ter entre 6 e 32 caracteres.");

            if (IsInvalid())
            {
                Senha = Senha.ConvertToMD5();
            }
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6,32, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "6", "32"));

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }
            AddNotifications(nome, email);
        }

        public void AlterarJogador(Nome nome, Email email, EnumSituacaoJogador status)
        {
            this.Nome = nome;
            this.Email = email;
            this.Status = status;

            new AddNotifications<Jogador>(this).IfFalse(Status == EnumSituacaoJogador.Ativo, "Só é possivel alterar Jogador se ele estiver Ativo.");

            AddNotifications(nome, email);
        }

        public Nome Nome { get; private set; }

        public Email Email { get; private set; }

        public string Senha { get; private set; }

        public EnumSituacaoJogador Status { get; private set; }

        public override string ToString()
        {
            return this.Nome.PrimeiroNome + " " + this.Nome.UltimoNome;
        }
    }
}
