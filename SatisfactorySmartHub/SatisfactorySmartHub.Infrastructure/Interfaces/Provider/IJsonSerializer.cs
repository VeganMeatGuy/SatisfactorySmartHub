using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Headers;

namespace SatisfactorySmartHub.Infrastructure.Interfaces.Provider;

/// <summary>
/// The json serializer interface.
/// Serves for the abstraction of <see cref="JsonSerializer"/> methods.
/// </summary>
internal interface IJsonSerializer
{
    ///<inheritdoc cref="JsonSerializer.Deserialize{TValue}(string, JsonSerializerOptions?)"/>
    public TValue? Deserialize<TValue>(string json) where TValue : class;

    /// <summary>
    /// Converts the value of a type specified by a generic type parameter into a JSON string.
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="value">The value to convert.</param>
    /// <param name="options">Options to control the conversion behavior.</param>
    /// <returns>A JSON string representation of the value</returns>
    /// <exception cref="NotSupportedException"></exception>
    public string Serialize<TValue>(TValue value, JsonSerializerOptions? options = null) where TValue : class;
}
