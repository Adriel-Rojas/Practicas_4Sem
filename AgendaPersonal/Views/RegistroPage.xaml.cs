using AgendaPersonal.Datos;
using AgendaPersonal.Modelos;

namespace AgendaPersonal.Views;

public partial class RegistroPage : ContentPage
{
    private readonly RegistroDatabase _database;

    public RegistroPage()
	{
		InitializeComponent();
        _database = new RegistroDatabase();
    }
    private async void RegiterButton_Clicked(object sender, EventArgs e)
    {
        if (!ValidarCampos()) return;

        try
        {
            var usuarioExistente = await _database.ExisteUsuarioAsync(UsernameEntry.Text);
            if (usuarioExistente)
            {
                await DisplayAlert("Error", "El nombre de usuario ya existe", "OK");
                return;
            }

            var emailExistente = await _database.ExisteEmailAsync(EmailEntry.Text);
            if (emailExistente)
            {
                await DisplayAlert("Error", "El correo electrónico ya está registrado", "OK");
                return;
            }

            var nuevoUsuario = new Contacto
            {
                Nombre = UsernameEntry.Text.Trim(),
                CorreoElectronico = EmailEntry.Text.Trim(),
                Password = PasswordEntry.Text,
                Activo = true
            };

            var resultado = await _database.GuardarUsuarioAsync(nuevoUsuario);

            if (resultado > 0)
            {
                await DisplayAlert("Éxito", "Registro completado", "OK");
                await Shell.Current.GoToAsync("//login");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al registrar: {ex.Message}", "OK");
        }
    }

    private bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
        {
            DisplayAlert("Error", "Nombre de usuario requerido", "OK");
            return false;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text) || !EmailEntry.Text.Contains("@"))
        {
            DisplayAlert("Error", "Correo electrónico inválido", "OK");
            return false;
        }

        if (string.IsNullOrWhiteSpace(PasswordEntry.Text) || PasswordEntry.Text.Length < 6)
        {
            DisplayAlert("Error", "La contraseña debe tener al menos 6 caracteres", "OK");
            return false;
        }

        return true;
    }
}