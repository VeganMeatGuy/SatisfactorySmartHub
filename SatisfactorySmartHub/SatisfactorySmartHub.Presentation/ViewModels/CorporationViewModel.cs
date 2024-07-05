using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Presentation.Interfaces.Services;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.ViewModels;

public sealed class CorporationViewModel(ICachingService cachingService): ViewModelBase
{
   public CorporationModel ActiveCorporation => cachingService.ActiveCorporation;
}
