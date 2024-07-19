using SatisfactorySmartHub.Application.Interfaces.Infrastructure.Persistence;
using SatisfactorySmartHub.Domain.Models;
using SatisfactorySmartHub.Infrastructure.Interfaces.Provider;
using System.Text.Json;


namespace SatisfactorySmartHub.Infrastructure.Persistance;

internal sealed class UserDataService(IFileProvider fileProvider, IJsonSerializer jsonSerializer) : IUserDataService
{
    private string _savingFilePath = Path.Combine(Environment.CurrentDirectory, "UserOptions.json");


    public UserDataModel GetUserData()
    {

        UserDataModel? UserData = null;


        if (fileProvider.Exists(_savingFilePath) == true)
            UserData = jsonSerializer.Deserialize<UserDataModel>(fileProvider.ReadAllText(_savingFilePath)) ?? throw new JsonException();

        if (UserData is null)
        {
            UserData = new UserDataModel();
            SetUserData(UserData);
        }
        return UserData;
    }

    public bool SetUserData(UserDataModel model)
    {
        try
        {
            string json = jsonSerializer.Serialize(model);
            fileProvider.WriteAllText(_savingFilePath, json);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


}
