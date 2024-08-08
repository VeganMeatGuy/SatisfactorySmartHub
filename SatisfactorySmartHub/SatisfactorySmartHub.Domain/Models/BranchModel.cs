namespace SatisfactorySmartHub.Domain.Models;

public sealed class BranchModel
{
    private string _name = string.Empty;
    private ExtractionSiteModel _extractionSite = new ExtractionSiteModel();
    private ProductionSiteModel _productionSite = new ProductionSiteModel();

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public ExtractionSiteModel ExtractionSite
    {
        get => _extractionSite;
        set => _extractionSite = value;
    }

    public ProductionSiteModel ProductionSite
    {
        get => _productionSite;
        set => _productionSite = value;
    }


}