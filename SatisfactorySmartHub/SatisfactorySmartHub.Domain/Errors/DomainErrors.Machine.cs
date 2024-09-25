using ErrorOr;

namespace SatisfactorySmartHub.Domain.Errors;

public static partial class DomainErrors
{
    public static class Machine
    {
        public static readonly Error MachineNameCannotBeNull = Error.Validation();
        public static readonly Error MachineNameCannotBeEmpty = Error.Validation();
    }
}
