using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Common;

public interface IUserOptions
{
    bool OverWriteSaveFile { get; set; }
}
