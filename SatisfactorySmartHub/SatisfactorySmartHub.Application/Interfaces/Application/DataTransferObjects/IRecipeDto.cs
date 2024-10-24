namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface IRecipeDto
{
    Guid Id { get; }
    string Name { get; set; }
}
