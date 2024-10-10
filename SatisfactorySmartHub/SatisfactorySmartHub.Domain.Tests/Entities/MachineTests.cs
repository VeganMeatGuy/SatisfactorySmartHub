using SatisfactorySmartHub.Domain.Entities;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

[TestClass]
public sealed partial class MachineTests
{
    private readonly static int _validMachineId = 1;
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
