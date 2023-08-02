using Newtonsoft.Json;
using StackExchange.Redis;
using ZeusInventarioWebAPI.Service;
using ConnectionHelper = ZeusInventarioWebAPI.Service.ConnectionHelper;

namespace PlasticaribeAPI.Service
{
    public class CacheService : ICacheService
    {
        private IDatabase _db;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public CacheService()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        {
            ConfigureRedis();
        }
        private void ConfigureRedis()
        {
            _db = ConnectionHelper.Connection.GetDatabase();
        }
        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
#pragma warning disable CS8604 // Posible argumento de referencia nulo
                return JsonConvert.DeserializeObject<T>(value);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
            }
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return default;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }
        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
        public object RemoveData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
            }
            return false;
        }
    }
}
