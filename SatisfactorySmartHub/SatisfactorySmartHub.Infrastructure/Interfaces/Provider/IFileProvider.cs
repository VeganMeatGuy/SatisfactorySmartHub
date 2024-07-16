namespace SatisfactorySmartHub.Infrastructure.Interfaces.Provider;

/// <summary>
/// The file provider interface.
/// Serves for the abstraction of <see cref="File"/> methods.
/// </summary>
internal interface IFileProvider
{
    ///<inheritdoc cref="File.Exists(string?)"/>
    bool Exists(string? path);

    /// <inheritdoc cref="File.WriteAllText(string, string?)"/>
    void WriteAllText(string path, string? contents);

    /// <inheritdoc cref="File.ReadAllText(string)"/>
    string ReadAllText(string path);
}
