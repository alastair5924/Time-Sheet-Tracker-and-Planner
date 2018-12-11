using Newtonsoft.Json;

namespace TImesheetTracker.Services
{
    public interface ISerializerService
    {
        T FromJson<T>(string json);
        string ToJson<T>(T data);
    }

    public class SerializerService : ISerializerService
    {
        public string ToJson<T>(T data)
        {
            return JsonConvert.SerializeObject(data,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
        }

        public T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json,
                new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
        }
    }
}
