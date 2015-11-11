using System;

namespace UserManagment
{
    public interface IUserInfo
    {
        DateTime Time { get; }
        string Country { get; }
        string Language { get; }
        string Ip { get; }
    }
}
