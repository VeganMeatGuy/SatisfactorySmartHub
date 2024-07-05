using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.Interfaces.Services;
public interface ICachingService : INotifyPropertyChanging, INotifyPropertyChanged
{
    CorporationModel ActiveCorporation { get; set; }
}
