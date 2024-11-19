using BusinessSoftware.Security;

namespace BusinessSoftware.Pages;

public partial class Login : ContentPage
{
    IBusinessSecurity security;
    public Login(IBusinessSecurity security)
    {
        InitializeComponent();
        this.security = security;
        security.AuthenticateAndAuthorize();
    }

    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        // After Login Success
      await Navigation.PushAsync(new Home(this.security));
    }
}