using System;
using System.Globalization;

namespace UserManagment
{
    public sealed class UserInfo : IUserInfo
    {

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
            get { return this.GetLanguage();}
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
