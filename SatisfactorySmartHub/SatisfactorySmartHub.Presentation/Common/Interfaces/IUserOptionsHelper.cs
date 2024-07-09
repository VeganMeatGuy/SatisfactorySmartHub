using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.Common.Interfaces;

public interface IUserOptionsHelper
{
    IUserOptions GetUserOptions();

    void SetUserOptions(IUserOptions options);

}
