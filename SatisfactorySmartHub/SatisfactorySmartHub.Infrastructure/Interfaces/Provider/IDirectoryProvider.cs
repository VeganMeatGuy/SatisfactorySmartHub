namespace SatisfactorySmartHub.Infrastructure.Interfaces.Provider;

/// <summary>
/// The file provider interface.
/// Serves for the abstraction of <see cref="Directory"/> methods.
/// </summary>
internal interface IDirectoryProvider
{
    /// <inheritdoc cref="Directory.Exists(string?)"/>
    bool Exists(string? path);

    ///<inheritdoc cref="Directory.GetFiles(string)"/>
    string[] GetFiles(string path);

    ///<inheritdoc cref="Directory.CreateDirectory(string)"/>
    void CreateDirectory(string path);
}

