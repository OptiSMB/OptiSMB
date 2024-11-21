using BusinessSoftware.AppContext;
using BusinessSoftware.Security;

namespace BusinessSoftware.Pages;

//[BusinessSoftwareBase]
public partial class Home : ContentPage
{
    IBusinessSecurity Security { get; set; }
    public Home(IBusinessSecurity security)
    {
        InitializeComponent();
        Security = security;
        Security.AuthenticateOrCreateUser(BusinessSoftwareContext.User);
    }
    private async void OnProfileClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new Pages.Profile());
    }

    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new Pages.SettingsPage());
    }

    protected override bool OnBackButtonPressed()
    {
        if (BusinessSoftwareContext.IsLoggedIn)
        {
            return true;
        }
        return false;
    }
}