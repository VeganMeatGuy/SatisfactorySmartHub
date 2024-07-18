namespace SatisfactorySmartHub.Infrastructure.Interfaces.Provider;

/// <summary>
/// The date time provider interface.
/// Serves for the abstraction of <see cref="DateTime"/> methods.
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
