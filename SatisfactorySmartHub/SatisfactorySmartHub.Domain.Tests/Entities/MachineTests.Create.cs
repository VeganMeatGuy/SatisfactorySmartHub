using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Errors;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

public sealed partial class MachineTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamIdIsEmptyGuid()
    {
        //act
        var result = Machine.Create(Guid.Empty, _validMachineName, _validMachinePowerConsumption);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.MachineErrors.IdCanNotBeEmptyGuid);

    }
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsNull()
    {
        //act
        var result = Machine.Create(_validMachineId, null, _validMachinePowerConsumption);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.MachineErrors.NameCanNotBeNull);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsEmpty()
    {
        //act
        var result = Machine.Create(_validMachineId, string.Empty, _validMachinePowerConsumption);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.MachineErrors.NameCanNotBeEmpty);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamPowerConsumptionIsSmalerThenZero()
    {
        //act
        var result = Machine.Create(_validMachineId, _validMachineName, -1);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.MachineErrors.PowerConsumptionCanNotBeNageative);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsMachine_WhenParamsAreValid()
    {
        //act
        var result = Machine.Create(_validMachineId, _validMachineName, _validMachinePowerConsumption);

        //assert
        Assert.IsFalse(result.IsError);
        Assert.IsNotNull(result.Value);
        Assert.AreEqual(_validMachineId, result.Value.Id);
        Assert.AreEqual(_validMachineName, result.Value.Name);
        Assert.AreEqual(_validMachinePowerConsumption, result.Value.PowerConsumption);
        Assert.IsInstanceOfType(result.Value, typeof(Machine));
    }
}
