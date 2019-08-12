using StackExchange.Redis;
using System;

namespace Oraculo
{
    class Program
    {
         static void Main(string[] args)
        {
            Console.WriteLine("Serviço online!");
            var redis = RedisRepositorio.getConnection().GetSubscriber();
            var db = RedisRepositorio.GetDb();
            redis.Subscribe("Perguntas", (ch, msg) =>
            {
                var array = msg.ToString().Split(":");
                db.HashSet(array[0], new HashEntry[] { new HashEntry("Equipe 1-2-3", "Palmeiras não tem mundial") });

                Console.WriteLine($"pergunta : {array[0]}, Hash: Equipe 1-2-3 | Palmeiras não tem mundial");
            });
            Console.ReadKey();
        }
    }
}
