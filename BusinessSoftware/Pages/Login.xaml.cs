using BusinessSoftware.Common;
using BusinessSoftware.Security;

namespace BusinessSoftware.Pages;

public partial class Login : ContentPage
{
    IBusinessSecurity Security;
    SecurityStatusCode StatusCode;
    public Login(IBusinessSecurity security)
    {
        InitializeComponent();
        Security = security;
    }
    private async void OnLoginOrSignupButtonClicked(object sender, EventArgs e)
    {
        StatusCode = Security.AuthenticateAndAuthorize(true, new User()
        {
            UserName = UsernameEntry.Text,
            Password = PasswordEntry.Text,
        }).GetAwaiter().GetResult();

        await Navigation.PushAsync(new Home(Security));
    }
}