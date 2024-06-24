using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Common;

/// <summary>
/// The observable object base class.
/// </summary>
public abstract class ObservableObjectBase : INotifyPropertyChanging, INotifyPropertyChanged
{
    /// <inheritdoc/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <inheritdoc/>
    public event PropertyChangingEventHandler? PropertyChanging;

    /// <summary>
    /// Sets a new value for a property and notifies about the change.
    /// </summary>
    /// <typeparam name="T">The type to work with.</typeparam>
    /// <param name="fieldValue">The referenced field.</param>
    /// <param name="newValue">The new value for the property.</param>
    /// <param name="propertyName">The name of the calling property.</param>
    protected void SetProperty<T>(ref T fieldValue, T newValue, [CallerMemberName] string propertyName = "")
    {
        if (!EqualityComparer<T>.Default.Equals(fieldValue, newValue))
        {
            RaisePropertyChanging(propertyName, fieldValue);
            fieldValue = newValue;
            RaisePropertyChanged(propertyName, newValue);
        }
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <typeparam name="T">The type to work with.</typeparam>
    /// <param name="propertyName">The name of the calling property.</param>
    /// <param name="value">The value of the calling property.</param>
    private void RaisePropertyChanged<T>(string propertyName, T value)
     => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs<T>(propertyName, value));

    /// <summary>
    /// Raises the <see cref="PropertyChanging"/> event.
    /// </summary>
    /// <param name="propertyName">The name of the calling property.</param>
    /// <param name="value">The value of the calling property.</param>
    private void RaisePropertyChanging<T>(string propertyName, T value)
            => PropertyChanging?.Invoke(this, new PropertyChangingEventArgs<T>(propertyName, value));
}

/// <summary>
/// The property changed event args class.
/// </summary>
/// <typeparam name="T">The type to work with.</typeparam>
public sealed class PropertyChangedEventArgs<T> : PropertyChangedEventArgs
{
    /// <summary>
    /// Initializes a instance of the property changed event args class.
    /// </summary>
    /// <remarks>
    /// Serves as extension to the <see cref="PropertyChangedEventArgs"/> class.
    /// </remarks>
    /// <param name="name">The name of the property that is changed.</param>
    /// <param name="value">The value of the property that is changed.</param>
    public PropertyChangedEventArgs(string name, T value) : base(name)
            => Value = value;

    /// <summary>
    /// The value of the property that is changed.
    /// </summary>
    public T Value { get; }
}

/// <summary>
/// The property changing event args class.
/// </summary>
/// <remarks>
/// Serves as extension to the <see cref="PropertyChangingEventArgs"/> class.
/// </remarks>
/// <typeparam name="T">The type to work with.</typeparam>
public sealed class PropertyChangingEventArgs<T> : PropertyChangingEventArgs
{
    /// <summary>
    /// Initializes a instance of the property changing event args class.
    /// </summary>
    /// <param name="name">The name of the property that is changing.</param>
    /// <param name="value">The value of the property that is changing.</param>
    public PropertyChangingEventArgs(string name, T value) : base(name)
            => Value = value;

    /// <summary>
    /// The value of the property that is changing.
    /// </summary>
    public T Value { get; }
}
