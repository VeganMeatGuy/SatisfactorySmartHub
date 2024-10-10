﻿using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Infrastructure.Persistance.Data
{
    internal static class Machines
    {
        public static MachineModel Smelter => new() { Name = "Smelter", PowerConsumption = 4 };
        public static MachineModel Constructor => new() { Name = "Constructor", PowerConsumption = 4 };
        public static MachineModel Packager => new() { Name = "Packager", PowerConsumption = 10 };
        public static MachineModel Assembler => new() { Name = "Assembler", PowerConsumption = 15 };
        public static MachineModel Foundry => new() { Name = "Foundry", PowerConsumption = 16 };
        public static MachineModel Refinery => new() { Name = "Refinery", PowerConsumption = 30 };
        public static MachineModel Manufacturer => new() { Name = "Manufacturer", PowerConsumption = 55 };
        public static MachineModel Blender => new() { Name = "Blender", PowerConsumption = 75 };
    }
}