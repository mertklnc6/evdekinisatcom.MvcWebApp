using System.ServiceModel.Channels;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using ISession = Microsoft.AspNetCore.Http.ISession;

namespace wissenProject1.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
