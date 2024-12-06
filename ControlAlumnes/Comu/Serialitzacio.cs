using Newtonsoft.Json;

namespace ControlAlumnes.Comu
{
    public static class Serialitzacio
    {
        public static string Serialitza(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None);
        }

        public static T Desserialitzar<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
