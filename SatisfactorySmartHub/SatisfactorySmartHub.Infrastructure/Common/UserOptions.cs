using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Common;

namespace SatisfactorySmartHub.Infrastructure.Common;

public sealed class UserOptions : IUserOptions
{
    private bool _overWriteSaveFile = false;

    public bool OverWriteSaveFile
    {
        get => _overWriteSaveFile;
        set => _overWriteSaveFile = value;
    }
}
