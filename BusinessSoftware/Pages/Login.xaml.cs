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
        // After Login Success.
        await Navigation.PushAsync(new Home(Security));
    }
    protected override void OnAppearing()
    {
        StatusCode =  Security.AuthenticateAndAuthorize(true).GetAwaiter().GetResult();

        if (StatusCode == SecurityStatusCode.RedirectToSignup)
        {
            LoginOrSignup.Text = "Enter UserName & Password to SignUp!";
        }
    }
}