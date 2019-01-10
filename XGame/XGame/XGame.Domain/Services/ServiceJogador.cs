using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {
                
        }

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AdicionarJogadorResponse", Message.X0_E_OBRIGATORIO.ToFormat("AdicionarJogadorResponse"));

                return null;
            }

            var email = new Email(request.Email);
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var jogador = new Jogador(nome, email,request.Senha);

            AddNotifications(jogador);

            if (this.IsInvalid())
            {
                return null;
            }
               
            jogador = _repositoryJogador.Adicionar(jogador);

            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AlterarJogadorResponse", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorResponse"));

                return null;
            }

            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);

            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);

                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);

            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador);

            if (IsInvalid())
            {

                return null;
            }

            _repositoryJogador.Editar(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequeste", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequeste"));

                return null;
            }

            var email = new Email(request.Email);

            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid()) {

                return null;
            }

            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco, x => x.Senha == jogador.Senha);
           
            return (AutenticarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositoryJogador.Listar().ToList().Select(jogador => (JogadorResponse)jogador).ToList();
        }

        public ResponseBase ExcluirJogador(Guid Id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(Id);

            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryJogador.Remover(jogador);

            return new ResponseBase();

        }
    }
}
