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
    public class Jogo : EntityBase
    {
        protected Jogo()
        {

        }
        private void ValidarJogo()
        {
            new AddNotifications<Jogo>(this)
             .IfNullOrInvalidLength(x => x.Nome, 1, 100, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Nome", "1", "100"))
             .IfNullOrInvalidLength(x => x.Descricao, 1, 255, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "255"))
             .IfNullOrInvalidLength(x => x.Genero, 1, 30, Message.X0_OBRIGATORIO_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Descrição", "1", "30"));
        }

        public Jogo(string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;

            ValidarJogo();
        }

        public void Alterar(string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;


            ValidarJogo();
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string Produtora { get; private set; }

        public string Distribuidora { get; private set; }

        public string Genero { get; private set; }

        public string Site { get; private set; }
    }
}
