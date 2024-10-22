using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Errors;
using System.Net.Http.Headers;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Branch : IdentityEntityBase
{
    //empty constructor for EF Core
    private Branch() { }

    public string Name { get; private set; } = string.Empty;

    //foreign key
    public Guid? CorporationId { get; private set; }

    //navigational properties
    public Corporation? Corporation { get; private set; }
    public IEnumerable<ProcessStep> ProcessSteps { get; private set; }  = new List<ProcessStep>();

public static ErrorOr<Branch> Create(string name)
    {
        ErrorOr<Success> ValidationResult = ValidateBrancheName(name);

        if (ValidationResult.IsError)
            return ValidationResult.FirstError;

        var branch = new Branch
        {
            Id = Guid.NewGuid(),
            Name = name,
        };
        return branch;
    }

    public ErrorOr<Success> ChangeName(string name)
    {
        ErrorOr<Success> ValidationResult = ValidateBrancheName(name);

        if (ValidationResult.IsError)
            return ValidationResult.FirstError;

        Name = name;
        return Result.Success;
    }

    public ErrorOr<Success> ChangeCorporationId(Guid corporationId)
    {
        CorporationId = corporationId;
        return Result.Success;
    }

    private static ErrorOr<Success> ValidateBrancheName(string name)
    {
        if (name == null)
            return DomainErrors.Branch.BranchNameCannotBeNull;

        if (name == string.Empty)
            return DomainErrors.Branch.BranchNameCannotBeEmpty;

        return Result.Success;
    }
}
