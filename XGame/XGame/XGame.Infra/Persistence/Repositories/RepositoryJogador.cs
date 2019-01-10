using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using System.Data.Entity;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador :RepositoryBase<Jogador, Guid>, IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context)
            : base(context)
        {
            _context = context;
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
