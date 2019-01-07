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

            //AutenticarJogadorRequest request = new AutenticarJogadorRequest();
            //Console.WriteLine("Criou request");

            //request.Email = "paulo@paulo.com";
            //request.Senha = "123456789";

            AdicionarJogadorRequest request = new AdicionarJogadorRequest()
            {
                Email="julio@hotmail.com",
                PrimeiroNome="Julio",
                UltimoNome="Francis",
                Senha = "123456"
            };

            var response = service.AdicionarJogador(request);

           // var response = service.AutenticarJogador(request);

            Console.WriteLine("Serviço é valido -> " + service.IsValid());

            service.Notifications.ToList().ForEach(x => {

                Console.WriteLine(x.Message);
            });

            Console.ReadKey();
        }
    }
}
