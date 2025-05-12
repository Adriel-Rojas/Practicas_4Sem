namespace AgendaPersonal;

public partial class ConfiguracionPage : ContentPage
{
	public ConfiguracionPage()
	{
		InitializeComponent();
	}

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        //await DisplayAlert("Cerrar Sesion", "Sesion Cerrada", "OK");

        if (await DisplayAlert("Estas seguro de cerrar sesion?", "Se cerrara su sesion.", "Si", "No"))
        {
            Preferences.Remove("UsuarioActual");
            SecureStorage.RemoveAll();
            await Shell.Current.GoToAsync("///login");
        }
    }
}