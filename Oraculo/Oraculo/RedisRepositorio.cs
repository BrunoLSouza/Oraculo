using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oraculo
{
    public class RedisRepositorio
    {
        private static ConnectionMultiplexer _connection { get; set; }
        public static IDatabase GetDb()
        {
            var redis = _connection;
            return redis.GetDatabase();
        }

        public static ConnectionMultiplexer getConnection()
        {
            if (_connection is null)
                _connection = ConnectionMultiplexer.Connect("40.77.24.62");
            return _connection;
        }
    }
}
