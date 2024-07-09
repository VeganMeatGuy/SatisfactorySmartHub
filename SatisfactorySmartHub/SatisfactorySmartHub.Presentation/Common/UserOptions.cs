using SatisfactorySmartHub.Presentation.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.Common;

public sealed class UserOptions : IUserOptions
{
    private bool _overWriteSaveFile = false;

    public bool OverWriteSaveFile
    {
        get => _overWriteSaveFile;
        set => _overWriteSaveFile = value;
    }
}
