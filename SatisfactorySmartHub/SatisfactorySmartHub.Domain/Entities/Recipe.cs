using ErrorOr;
using SatisfactorySmartHub.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public sealed class Recipe : IdentityEntityBase
{
    //empty constructor for EF Core
    private Recipe() { }

    public string Name { get; init; } = string.Empty;

public static ErrorOr<Recipe> Create(Guid id, string name)
    {
        //ErrorOr<Success> ValidationResult = ValidateBrancheName(name);

        //if (ValidationResult.IsError)
        //    return ValidationResult.FirstError;

        var recipe = new Recipe
        {
            Id = id,
            Name = name,
        };
        return recipe;
    }
}
