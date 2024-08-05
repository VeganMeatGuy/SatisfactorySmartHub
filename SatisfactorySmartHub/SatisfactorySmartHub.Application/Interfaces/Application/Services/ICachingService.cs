﻿using SatisfactorySmartHub.Domain.Models;
using System.ComponentModel;

namespace SatisfactorySmartHub.Application.Interfaces.Application.Services;
public interface ICachingService : INotifyPropertyChanging, INotifyPropertyChanged
{
    CorporationModel ActiveCorporation { get; }
    bool ActiveCorporationIsSet { get; }
    void SetActiveCorporation(CorporationModel corporationModel);
}
