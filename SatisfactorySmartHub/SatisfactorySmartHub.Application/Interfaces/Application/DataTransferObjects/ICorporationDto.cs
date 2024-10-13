using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface ICorporationDto
{
    Guid Id { get;}
    string Name { get; set; }
}
