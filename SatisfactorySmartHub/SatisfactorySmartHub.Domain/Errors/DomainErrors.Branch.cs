using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Errors;

public static partial class DomainErrors
{
    public static class Branch
    {
        public static readonly Error BranchNameCannotBeNull = Error.Validation();
        public static readonly Error BranchNameCannotBeEmpty = Error.Validation();
    }
}

