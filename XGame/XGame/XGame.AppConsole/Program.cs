using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando .....");

            var service = new ServiceJogador();
            Console.WriteLine("Criou Instancia");

            AutenticarJogadorRequest request = new AutenticarJogadorRequest();


            service.AutenticarJogador(request);
        }
    }
}
