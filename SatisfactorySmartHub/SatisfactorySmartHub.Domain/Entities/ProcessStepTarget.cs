using SatisfactorySmartHub.Domain.Entities.Base;

namespace SatisfactorySmartHub.Domain.Entities;

public class ProcessStepTarget : ItemWithAmountBase
{
    //empty constructor for EF Core
    private ProcessStepTarget() { }

    //foreign key
    public Guid ProcessStepId { get; private set; }

    //navigational properties
    public ProcessStep ProcessStep { get; private set; }
}
