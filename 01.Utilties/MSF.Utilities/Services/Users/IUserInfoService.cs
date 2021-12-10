using System;

namespace MSF.Utilities.Services.Users
{
    public interface IUserInfoService
    {
        Guid UserId();
        string GetUserIp();
        string GetLastName();
        string GetUsername();
        string GetFirstName();
        string GetUserAgent();
        bool HasAccess(string accessKey);
        bool IsCurrentUser(string userId);
    }
}
