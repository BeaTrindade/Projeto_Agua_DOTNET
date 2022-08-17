using System.Text.Json.Serialization;

namespace PeixeLegal.Src.Utilidades
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Portadores {USER,ADMIN}
}
