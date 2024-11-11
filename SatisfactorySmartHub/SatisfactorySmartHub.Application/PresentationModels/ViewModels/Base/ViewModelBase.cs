using SatisfactorySmartHub.Domain.Common;
using System.ComponentModel;

namespace SatisfactorySmartHub.Application.PresentationModels.ViewModels.Base;


/// <summary>
/// The view model base class.
/// </summary>
public abstract class ViewModelBase : ObservableObjectBase, INotifyPropertyChanging, INotifyPropertyChanged
{ }
