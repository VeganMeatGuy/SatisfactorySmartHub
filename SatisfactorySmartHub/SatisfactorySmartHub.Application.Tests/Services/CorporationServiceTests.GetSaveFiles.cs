using Moq;
using SatisfactorySmartHub.Application.Services;
using SatisfactorySmartHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatisfactorySmartHub.Application.Tests.Services;

public sealed partial class CorporationServiceTests
{
    [TestMethod]
    public void GetSaveFiles_ReturnListWithEntries_WhenSavedCorporationExist()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        ICollection<string> saveFiles = new List<string>() { "file1", "file2", "file3"};
        _corporationFileServiceMock.Setup(x => x.GetSaveFiles()).Returns(saveFiles);


        // act
        ICollection<string>? result = service.GetSaveFiles();

        // assert
        Assert.IsNotNull(result);
        Assert.AreEqual(3,result.Count);
       _corporationFileServiceMock.Verify(x => x.GetSaveFiles(), Times.Once);
    }

    [TestMethod]
    public void GetSaveFiles_ReturnmptyList_WhenNoneSavedCorporationExist()
    {
        //arrange
        CorporationService service = CreateMockedInstance();
        _corporationFileServiceMock.Setup(x => x.GetSaveFiles()).Returns(new List<string>());


        // act
        ICollection<string>? result = service.GetSaveFiles();

        // assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
        _corporationFileServiceMock.Verify(x => x.GetSaveFiles(), Times.Once);
    }
}
