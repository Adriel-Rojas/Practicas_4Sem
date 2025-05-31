using System.Threading.Tasks;
using AgendaPersonal.Datos;
using AgendaPersonal.Modelos;

namespace AgendaPersonal.Views;

public partial class LoginPage : ContentPage
{
    private readonly RegistroDatabase _database;
    public LoginPage()
	{
		InitializeComponent();
        _database = new RegistroDatabase();
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
        //if (IsCredentialCorrect(Username.Text, Password.Text))
        //{
        //    Username.Text = string.Empty;
        //    Password.Text = string.Empty;
        //    Preferences.Set("UsuarioActual", Username.Text.Trim());
        //    await SecureStorage.SetAsync("hasAuth", "true");
        //    await Shell.Current.GoToAsync("///main");
        //}
        //else
        //{
        //    Preferences.Remove("UsuarioActual");
        //    await DisplayAlert("Acceso fallido", "Usuario o contraseña invalido", "Intente otra vez");
        //}

        string username = Username.Text?.Trim();
        string password = Password.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, ingresa nombre de usuario y contraseña", "OK");
            return;
        }

        var usuario = await _database.ObtenerUsuarioAsync(username);

        if (usuario == null)
        {
            await DisplayAlert("Error", "Usuario no encontrado", "OK");
            return;
        }

        if (usuario.Password != password)
        {
            await DisplayAlert("Error", "Contraseña incorrecta", "OK");
            return;
        }

        // Login exitoso, navegar a la página principal
        await Shell.Current.GoToAsync("//main");
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