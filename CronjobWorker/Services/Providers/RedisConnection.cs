using StackExchange.Redis;

namespace CronjobWorker.Services.Providers;

public class RedisConnection
{
    public static IConnectionMultiplexer Connect(string connectionString)
    {
        return ConnectionMultiplexer.Connect(connectionString);
    }
}
