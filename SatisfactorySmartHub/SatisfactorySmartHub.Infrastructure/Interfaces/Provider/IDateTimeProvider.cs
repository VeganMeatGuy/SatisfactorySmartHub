namespace SatisfactorySmartHub.Infrastructure.Interfaces.Provider;

/// <summary>
/// The date time provider interface.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// <inheritdoc cref="DateTime.Now"/>
    /// </summary>
    DateTime Now { get; }

    /// <summary>
    /// <inheritdoc cref="DateTime.Today"/>
    /// </summary>
    DateTime Today { get; }
}
