﻿using CommunityToolkit.Mvvm.Input;
using SatisfactorySmartHub.Presentation.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Presentation.ViewModels;

public sealed class HubViewModel : ViewModelBase
{

    private IRelayCommand? _loadCompanyCommand;
    private IRelayCommand? _createCompanyCommand;
    private string _companyName = string.Empty;
    private string _createHint = string.Empty;
    private string _loadHint = string.Empty;

    public HubViewModel() { }

    public IRelayCommand CreateCompanyCommand => _createCompanyCommand ?? new RelayCommand(new Action(CreateCompany));
    public IRelayCommand LoadCompanyCommand => _loadCompanyCommand ?? new RelayCommand(new Action(LoadCompany));

    public string CompanyName
    {
        get => _companyName;
        set => SetProperty(ref _companyName, value);
    }

    public string CreateHint
    {
        get => _createHint;
        set => SetProperty(ref _createHint, value);
    }

    public string LoadHint
    {
        get => _loadHint;
        set => SetProperty(ref _loadHint, value);
    }

    private void CreateCompany()
    { 

    }
    private void LoadCompany()
    {

    }
}
