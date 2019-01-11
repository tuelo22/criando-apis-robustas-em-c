using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Entities;

namespace XGame.Domain.Arguments.Jogo
{
    public class JogoResponse
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Produtora { get; set; }

        public string Distribuidora { get; set; }

        public string Genero { get; set; }

        public string Site { get; set; }

        public static explicit operator JogoResponse(Entities.Jogo entidade)
        {
            return new JogoResponse
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Descricao = entidade.Descricao,
                Produtora = entidade.Produtora,
                Distribuidora = entidade.Distribuidora,
                Genero = entidade.Genero,
                Site = entidade.Site
            };
        }
    }
}
