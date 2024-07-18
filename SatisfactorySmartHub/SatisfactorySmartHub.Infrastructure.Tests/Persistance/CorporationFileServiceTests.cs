using Moq;
using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using SatisfactorySmartHub.Infrastructure.Persistance;

namespace SatisfactorySmartHub.Infrastructure.Tests.Persistance;

[TestClass]
public sealed partial class CorporationFileServiceTests
{
    private Mock<IFileProvider> _fileProviderMock = new();
    private Mock<IDirectoryProvider> _directoryProviderMock = new();
    private Mock<IDateTimeProvider> _dateTimeProviderMock = new();
    private Mock<IJsonSerializer> _jsonSerializerMock = new();

    [TestMethod]
    [TestCategory("Constructor")]
    public void CorporationFileServiceTest()
    {
        ICorporationFileService? corporationFileService;

        corporationFileService = CreateMockedInstance();

        Assert.IsNotNull(corporationFileService);
    }


    /// <summary>
    /// Creates a new instance of the <see cref="CorporationFileServiceTests"/> class with mocked dependencies.
    /// </summary>
    /// <returns>The new instance with mocked dependencies.</returns>
    private CorporationFileService CreateMockedInstance()
    {
        _fileProviderMock = new();
        _directoryProviderMock = new();
        _dateTimeProviderMock = new();
        _jsonSerializerMock = new();


        return new CorporationFileService(
            _fileProviderMock.Object, 
            _directoryProviderMock.Object, 
            _dateTimeProviderMock.Object,
            _jsonSerializerMock.Object);
    }
}