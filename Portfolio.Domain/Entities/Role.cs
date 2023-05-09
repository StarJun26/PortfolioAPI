using System.Text.Json.Serialization;

namespace Portfolio.Domain.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Admin,
        User
    }
}
