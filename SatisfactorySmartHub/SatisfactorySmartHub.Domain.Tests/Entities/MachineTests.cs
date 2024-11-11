using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

[TestClass]
public sealed partial class MachineTests
{
    private readonly static Guid _validMachineId = Guid.Parse("e378688b-8b73-4247-be55-ccb300783655");
    private readonly static string _validMachineName = "ValidMachineName";
    private readonly static int _validMachinePowerConsumption = 1;

    [TestMethod]
    [TestCategory("Constructor")]
    public void MachineTest()
    {
        // arrange
        Machine? machine;
        //act
        machine = CreateMockedInstance();

        //assert
        Assert.IsNotNull(machine);
    }

    private Machine CreateMockedInstance()
    {
        return Machine.Create(_validMachineId, _validMachineName, _validMachinePowerConsumption).Value;
    }
}
