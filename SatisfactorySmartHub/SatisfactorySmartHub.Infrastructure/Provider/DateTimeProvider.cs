using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;

namespace SatisfactorySmartHub.Infrastructure.Provider;

/// <summary>
/// The date time provider class.
/// </summary>
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;

    public DateTime Today => DateTime.Today;
}
