using SatisfactorySmartHub.Domain.Entities;
using SatisfactorySmartHub.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

public sealed partial class MachineTests
{
    [TestMethod]
    [TestCategory("Method")]
    public void Create_ThrowsException_WhenParamNameIsNull()
    {
        //act
        var result = Machine.Create(null);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Machine.MachineNameCannotBeNull);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_ThrowsException_WhenParamNameIsEmpty()
    {
        //act
        var result = Machine.Create(string.Empty);

        //assert
        Assert.IsTrue(result.IsError);
        Assert.AreEqual(result.FirstError, DomainErrors.Machine.MachineNameCannotBeEmpty);
    }

    [TestMethod]
    [TestCategory("Method")]
    public void Create_IdIsNotAnEmptyGuid()
    {
        //act
        var result = CreateMockedInstance();

        //assert
        Assert.AreNotEqual(Guid.Empty, result.Id);
 }

}
