namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface IBranchDto
{
    Guid Id { get; }
    string Name { get; set; }
    Guid? CorporationId { get; }
}
