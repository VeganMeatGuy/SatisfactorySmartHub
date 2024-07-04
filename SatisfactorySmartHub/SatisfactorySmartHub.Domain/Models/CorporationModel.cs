using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Models;

public sealed class CorporationModel
{
    private string _name = string.Empty;
    private ICollection<BranchModel> _branch = new HashSet<BranchModel>();
    private ICollection<PowerPlantModel> _powerPlant = new HashSet<PowerPlantModel>();
    private LogisticsModel _logistics = new LogisticsModel();


    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public ICollection<BranchModel> Branches
    {
        get => _branch;
        set => _branch = value;
    }


    public ICollection<PowerPlantModel> PowerPlants
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
