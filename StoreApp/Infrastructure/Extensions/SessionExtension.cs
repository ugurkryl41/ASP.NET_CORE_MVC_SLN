using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions
{
    public static class SessionExtension
    {
        //ISession  içerisine SetJson metotu ekledik yani ISession genişlettik.
        public static void SetJson(this ISession session, string key,object value)  
        {
            session.SetString(key,JsonSerializer.Serialize(value));   
        }

        public static void SetJson<T>(this ISession session, string key, T value)  //T'ye bağlı çalışıyoruz tip güvenliği sağladık. object kullanmadık.
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetJson<T>(this ISession session,string key)
        {
            var data = session.GetString(key);

            return data is null
                ? default(T)
                : JsonSerializer.Deserialize<T>(data);
        }
    }
}
