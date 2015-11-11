using System;
using System.Globalization;

namespace UserManagment
{
    public sealed class UserInfo : IUserInfo
    {

        private static UserInfo instance;

        private UserInfo() { }

        public static UserInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInfo();
                }
                return instance;
            }
        }

        public DateTime Time
        {
            get { return this.GetDate(); }
        }

        public string Country
        {
            get { return this.GetCountry(); }
        }

        public string Language
        {
            get { return this.GetLanguage(); }
        }

        public string Ip
        {
            get { return this.GetIp(); }
        }

        private DateTime GetDate()
        {
            return DateTime.Now.ToUniversalTime();
        }

        private string GetCountry()
        {
            return RegionInfo.CurrentRegion.DisplayName;
        }

        private string GetLanguage()
        {
            return CultureInfo.CurrentCulture.DisplayName;
        }

        private string GetIp()
        {
            return "192.168.1.1";
        }
    }
}
