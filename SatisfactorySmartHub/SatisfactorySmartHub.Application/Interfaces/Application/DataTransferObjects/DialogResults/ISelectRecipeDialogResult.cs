using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects.DialogResults;

public interface ISelectRecipeDialogResult
{
    Guid RecipeId { get; set; } 
}
