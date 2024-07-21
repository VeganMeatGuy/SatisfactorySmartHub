namespace SatisfactorySmartHub.Domain.Models;

public sealed class UserDataModel
{
    private bool _overWriteSaveFile = false;

    public bool OverWriteSaveFile
    {
        get => _overWriteSaveFile;
        set => _overWriteSaveFile = value;
    }
}
