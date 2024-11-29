using ErrorOr;

namespace SatisfactorySmartHub.Domain.Errors;

public static partial class DomainErrors
{
    public static class ItemErrors
    {
        public static readonly Error IdCanNotBeEmptyGuid = Error.Validation();
        public static readonly Error NameCanNotBeNull = Error.Validation();
        public static readonly Error NameCanNotBeEmpty = Error.Validation();
    }
}
