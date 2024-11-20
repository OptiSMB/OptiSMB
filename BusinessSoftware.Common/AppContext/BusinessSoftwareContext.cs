using BusinessSoftware.Common;

namespace BusinessSoftware.AppContext
{
    public static class BusinessSoftwareContext
    {
        public static User User { get; set; }
        public static TimeSpan IdleTimeout { get; set; }
        public static bool IsLoggedIn { get; set; }
        public static DateTime LastLoggedIn { get; set; }
        static BusinessSoftwareContext()
        {
            User = new User();
            IdleTimeout = TimeSpan.FromMinutes(20);
            IsLoggedIn = false;
            LastLoggedIn = DateTime.MaxValue;
        }
    }
}
