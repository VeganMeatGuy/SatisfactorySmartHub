﻿namespace SatisfactorySmartHub.Application.Interfaces.Application.DataTransferObjects;

public interface ICorporationDto
{
    Guid Id { get; }
    string Name { get; set; }
}
