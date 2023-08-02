using StackExchange.Redis;

namespace ZeusInventarioWebAPI.Service
{
    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
#pragma warning disable CS8604 // Posible argumento de referencia nulo
                return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
