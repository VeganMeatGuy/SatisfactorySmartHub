using SatisfactorySmartHub.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Entities;

public class ByProduct : ItemWithAmountBase
{
    //empty constructor for EF Core
    private ByProduct() { }

    //foreign key
    public Guid RecipeId { get; private set; }

    //navigational properties
    public Recipe Recipe { get; private set; }
}
