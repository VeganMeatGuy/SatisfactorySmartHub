using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Models;

public sealed class CorporationModel
{
    private string _name = string.Empty;
    private BranchModel _branch = new BranchModel();
    private PowerPlantModel _powerPlant = new PowerPlantModel();
    private LogisticsModel _logistics = new LogisticsModel();


    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public BranchModel Branch
    {
        get => _branch;
        set => _branch = value;
    }

    public PowerPlantModel PowerPlant
    {
        get => _powerPlant;
        set => _powerPlant = value;
    }

    public LogisticsModel Logistics
    {
        get => _logistics;
        set => _logistics = value;
    }
}
