using AgendaPersonal.Utils;
using System.Globalization;

namespace AgendaPersonal.Views;

public partial class ConfiguracionPage : ContentPage
{
	public ConfiguracionPage()
	{
		InitializeComponent();

        temaSwitch.IsToggled = ConfiguracionApp.ObtenerTema();
        idiomaPicker.SelectedItem = ConfiguracionApp.ObtenerIdioma();
    }
    private void OnTemaToggled(object sender, ToggledEventArgs e)
    {
        ConfiguracionApp.GuardarTema(e.Value);

        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;

        lblEstado.IsVisible = true;
    }

    private void OnIdiomaChanged(object sender, EventArgs e)
    {
        string? idiomaSeleccionado = idiomaPicker.SelectedItem.ToString();

        if (idiomaSeleccionado != null)
            ConfiguracionApp.GuardarIdioma(idiomaSeleccionado);

        // Aplicar cultura al hilo actual
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(idiomaSeleccionado);
        Thread.CurrentThread.CurrentCulture = new CultureInfo(idiomaSeleccionado);

        // Actualizar UI con nuevos textos
        ActualizarTextos();
        lblEstado.IsVisible = true;
    }

    private void ActualizarTextos()
    {
        return;
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