using System.Xml.Linq;

namespace SatisfactorySmartHub.Domain.Models;

public sealed class BranchModel
{
    private string _name = string.Empty;
    private ExtractionSiteModel _extractionSite = new ExtractionSiteModel();
    private ProductionLineModel _productionSite = new ProductionLineModel();

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public ExtractionSiteModel PowerPlant
    {
        get => _extractionSite;
        set => _extractionSite = value;
    }

    public ProductionLineModel ProductionSite
    {
        get => _productionSite;
        set => _productionSite = value;
    }


}