using ErrorOr;

namespace SatisfactorySmartHub.Domain.Errors;
public static partial class DomainErrors
{
    public static class Corporation
    {
        public static readonly Error CorporationNameCannotBeNull = Error.Validation();
        public static readonly Error CorporationNameCannotBeEmpty = Error.Validation();
    }
}
