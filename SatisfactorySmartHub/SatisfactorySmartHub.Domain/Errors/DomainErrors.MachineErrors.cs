using ErrorOr;

namespace SatisfactorySmartHub.Domain.Errors;

public static partial class DomainErrors
{
    public static class MachineErrors
    {
        public static readonly Error IdCanNotBeEmptyGuid = Error.Validation();
        public static readonly Error NameCanNotBeNull = Error.Validation();
        public static readonly Error NameCanNotBeEmpty = Error.Validation();
        public static readonly Error PowerConsumptionCanNotBeNageative = Error.Validation();
    }
}
