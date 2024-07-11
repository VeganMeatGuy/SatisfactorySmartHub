using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Common;

public interface IUserOptionsHelper
{
    IUserOptions GetUserOptions();

    void SetUserOptions(IUserOptions options);

}
