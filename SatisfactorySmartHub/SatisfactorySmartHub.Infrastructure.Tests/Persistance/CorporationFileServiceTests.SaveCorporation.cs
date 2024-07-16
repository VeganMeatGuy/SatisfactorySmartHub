using Moq;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

public sealed partial class CorporationFileServiceTests
{
    [TestMethod]
    [TestCategory("Methods")]
    public void SaveCorporation_ShouldReturnTrueWhenSuccessful()
    {
        string testCorporationName = "unittest";
        
        CorporationFileService service = CreateMockedInstance();

        string filePath = Path.Combine(service.DefaultFolderPath,$"{testCorporationName}.json");

        //_fileProviderMock.Setup(x => x.WriteAllText(filePath, It.IsAny<string>()));


        CorporationModel corporation = new();
        corporation.Name = testCorporationName;

        bool result = service.SaveCorporation(corporation, true);

        Assert.IsTrue(result);

        _fileProviderMock.Verify(x => x.WriteAllText(filePath, It.IsAny<string>()),Times.Once);

        //Assert.AreEqual(1, _fileProviderMock.Invocations.Count);

    }
}
