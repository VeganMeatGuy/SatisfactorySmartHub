using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface IProcessStepDto
{
    Guid Id { get; }
    Guid BranchId { get; }
}
