using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Errors;

public static partial class ApplicationErrors
{
    public static class CorporationService
    {
        public static readonly Error CorporationWasNotInDb = Error.NotFound();
    }
}
