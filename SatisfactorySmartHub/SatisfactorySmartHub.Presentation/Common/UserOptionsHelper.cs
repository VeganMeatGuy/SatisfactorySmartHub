using SatisfactorySmartHub.Presentation.Common.Interfaces;
using System.IO;
using System.Text.Json;


namespace SatisfactorySmartHub.Presentation.Common;

public sealed class UserOptionsHelper : IUserOptionsHelper
{
    private string _savingPath = Path.Combine(Environment.CurrentDirectory, "UserOptions.json");


    public IUserOptions GetUserOptions()
    {

        UserOptions? userOptions = null;


        if (File.Exists(_savingPath) == true)
            userOptions = JsonSerializer.Deserialize<UserOptions>(File.ReadAllText(_savingPath));

        if (userOptions is null)
        {
            userOptions = new UserOptions();
            SetUserOptions(userOptions);
        }
        return userOptions;
    }

    public void SetUserOptions(IUserOptions options)
    {
        string json = JsonSerializer.Serialize(options);
        File.WriteAllText(_savingPath, json);
    }


}
