﻿using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using System.Data.Entity;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context)
        {
            _context = context;
        }

        public Jogador AdicionarJogador(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            _context.SaveChanges();

            return jogador;
        }

        public void AlterarJogador(Jogador jogador)
        {
            throw new NotImplementedException();
        }

        public Jogador AutenticarJogador(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogador> ListarJogador()
        {
            return _context.Jogadores.ToList();
        }

        public Jogador ObterJogadorPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        //public int CalculaJogadores()
        //{
        //    string nome = "Paulo";
        //    string ultimonome = "marques";
        //    string sexo = string.Empty;

        //    //AsNoTracking remove o mapeamento(Controle do Entity) e acelera a consulta
        //    IQueryable<Jogador> jogadores = _context.Jogadores.AsNoTracking().AsQueryable();

        //    if (!string.IsNullOrEmpty(nome))
        //    {
        //        jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(nome));
        //    }

        //    if (!string.IsNullOrEmpty(ultimonome))
        //    {
        //        jogadores = jogadores.Where(x => x.Nome.UltimoNome.StartsWith(ultimonome));
        //    }

        //    if (!string.IsNullOrEmpty(sexo))
        //    {
        //        jogadores = jogadores.Where(x => x.Nome.PrimeiroNome.StartsWith(nome));
        //    }

        //    // Só vai no banco quando for dado o ToList a query está sendo mondada
        //    // AsParallel() Permitie mais de um processador ou nucleo ou sej usa tread para a consulta
        //    return jogadores.AsParallel().ToList().Count();

        //    //var jogadoresativos = _context.Jogadores.Where(x => x.Status == Domain.Enum.EnumSituacaoJogador.Ativo).ToList();

        //    //   var JogadoresQueComtemP = jogadoresativos.Where(x => x.Nome.PrimeiroNome.Contains("P")).ToList();

        //}
    }
}
