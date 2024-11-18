using BusinessSoftware.Security;

namespace BusinessSoftware
{
    public partial class App : Application
    {
        IBusinessSecurity security;
        public App(IBusinessSecurity security)
        {
            InitializeComponent();
            this.security = security;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Create a new window
            var window = new Window
            {
                Title = "Business Software", // Set window title
                Page = new NavigationPage(new Pages.Login(this.security))
                {
                    BarBackgroundColor = Colors.Black,
                    BarTextColor = Colors.White,
                },
            };

            return window;
        }
    }
}
