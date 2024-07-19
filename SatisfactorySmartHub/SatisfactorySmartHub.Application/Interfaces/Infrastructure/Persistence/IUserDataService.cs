using SatisfactorySmartHub.Domain.Models;

namespace SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;

public interface IUserDataService
{
    UserDataModel GetUserData();

    bool SetUserData(UserDataModel model);

}
