using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using SatisfactorySmartHub.Domain.Errors;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Corporation : IdentityEntityBase
{
    //empty constructor for EF Core
    private Corporation() { }

    public string Name { get; private set; } = string.Empty;
    //navigational properties
    public IEnumerable<Branch> Branches { get; } = new List<Branch>();

    public static ErrorOr<Corporation> Create(string name)
    {
        ErrorOr<Success> ValidationResult = ValidateCorporationName(name);

        if (ValidationResult.IsError)
            return ValidationResult.FirstError;

        var corporation = new Corporation
        {
            Id = Guid.NewGuid(),
            Name = name
        };
        return corporation;
    }

    public ErrorOr<Success> ChangeName(string name)
    {
        ErrorOr<Success> ValidationResult = ValidateCorporationName(name);

        if (ValidationResult.IsError)
            return ValidationResult.FirstError;

        Name = name;
        return Result.Success;
    }

    private static ErrorOr<Success> ValidateCorporationName(string name)
    {
        if (name == null)
            return DomainErrors.Corporation.CorporationNameCannotBeNull;

        if (name == string.Empty)
            return DomainErrors.Corporation.CorporationNameCannotBeEmpty;

        return Result.Success;
    }

}
