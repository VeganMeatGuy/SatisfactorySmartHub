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
        Assert.AreEqual(result.FirstError, DomainErrors.Machine.MachineIdCannotBeEmptyGuid);

    }
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsNull()
    {
        //act
        var result = Machine.Create(_validMachineId, null, _validMachinePowerConsumption);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Machine.MachineNameCannotBeNull);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ReturnsError_WhenParamNameIsEmpty()
    {
        //act
        var result = Machine.Create(_validMachineId, string.Empty, _validMachinePowerConsumption);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Machine.MachineNameCannotBeEmpty);
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
        Assert.IsInstanceOfType(result.Value, typeof(Machine));
    }
}
