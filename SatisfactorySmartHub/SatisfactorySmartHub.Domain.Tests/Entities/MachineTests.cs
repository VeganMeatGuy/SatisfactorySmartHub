using SatisfactorySmartHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Domain.Tests.Entities;

[TestClass]
public sealed partial class MachineTests
{
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
        return Machine.Create("MockedMachine").Value;
    }
}
