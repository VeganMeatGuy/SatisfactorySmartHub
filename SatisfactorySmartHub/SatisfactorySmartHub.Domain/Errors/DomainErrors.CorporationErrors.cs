using ErrorOr;

namespace SatisfactorySmartHub.Domain.Errors;
public static partial class DomainErrors
{
    public static class CorporationErrors
    {
        public static readonly Error NameCannotBeNull = Error.Validation();
        public static readonly Error NameCannotBeEmpty = Error.Validation();
    }
}
