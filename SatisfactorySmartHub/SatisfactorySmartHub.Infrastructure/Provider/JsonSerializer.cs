using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using System.Text.Json;

namespace SatisfactorySmartHub.Infrastructure.Provider;

internal sealed class JsonSerializer : IJsonSerializer
{
    public TValue? Deserialize<TValue>(string json) where TValue : class
        => System.Text.Json.JsonSerializer.Deserialize<TValue>(json);

    public string Serialize<TValue>(TValue value, JsonSerializerOptions? options = null) where TValue : class
    => System.Text.Json.JsonSerializer.Serialize<TValue>(value, options);
}
