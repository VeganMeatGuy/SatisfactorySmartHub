using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;

namespace SatisfactorySmartHub.Infrastructure.Provider;

/// <summary>
/// The file provider class
/// </summary>
internal sealed class FileProvider : IFileProvider
{
    public bool Exists(string? path) 
        => File.Exists(path);


    public string ReadAllText(string path) 
        => File.ReadAllText(path);

    public void WriteAllText(string path, string? contents) 
        => File.WriteAllText(path, contents);
}
