using SatisfactorySmartHub.Domain.Common;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Presentation.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.Services;

internal class CachingService :  ObservableObjectBase, ICachingService
{
    private CorporationModel? _activeCorporationModel;

    public CorporationModel? ActiveCorporation 
    { 
        get => _activeCorporationModel; 
        set => SetProperty(ref _activeCorporationModel, value); 
    }
}
