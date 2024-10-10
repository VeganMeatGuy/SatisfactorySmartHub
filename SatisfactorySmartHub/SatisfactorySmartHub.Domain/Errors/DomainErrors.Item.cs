using ErrorOr;

namespace SatisfactorySmartHub.Domain.Errors;

public static partial class DomainErrors
{
    public static class Item
    {
        public static readonly Error ItemIdCannotBeZero = Error.Validation();
        public static readonly Error ItemNameCannotBeNull = Error.Validation();
        public static readonly Error ItemNameCannotBeEmpty = Error.Validation();
    }
}
