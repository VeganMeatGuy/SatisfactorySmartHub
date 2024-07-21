using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Provider;

internal sealed class DirectoryProvider : IDirectoryProvider
{
    public bool Exists(string? path)
        => Directory.Exists(path);
    public string[] GetFiles(string path)
        => Directory.GetFiles(path);
    public void CreateDirectory(string path)
    => Directory.CreateDirectory(path);
}
