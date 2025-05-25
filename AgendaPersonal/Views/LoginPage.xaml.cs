using System.Threading.Tasks;

namespace AgendaPersonal.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
    protected override bool OnBackButtonPressed()
    {
        Application.Current.Quit();
        return true;
    }

    private async void TapGestureRecognizerPwd_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("recuperar");
    }
    private async void TapGestureRecognizerReg_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("registro");
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        if (IsCredentialCorrect(Username.Text, Password.Text))
        {
            Username.Text = string.Empty;
            Password.Text = string.Empty;
            Preferences.Set("UsuarioActual", Username.Text.Trim());
            await SecureStorage.SetAsync("hasAuth", "true");
            await Shell.Current.GoToAsync("///main");
        }
        else
        {
            Preferences.Remove("UsuarioActual");
            await DisplayAlert("Acceso fallido", "Usuario o contraseña invalido", "Intente otra vez");
        }
    }

    //Para que no aparezca menu de 3 rayas
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
    }


    bool IsCredentialCorrect(string username, string password)
    {
        return Username.Text == "adriel" && Password.Text == "1234";
    }
}