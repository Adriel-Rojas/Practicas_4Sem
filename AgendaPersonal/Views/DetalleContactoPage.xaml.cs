using AgendaPersonal.Modelos;
using AgendaPersonal.Datos;
using Microsoft.Maui.Controls;

namespace AgendaPersonal.Views;

public partial class DetalleContactoPage : ContentPage, IQueryAttributable
{
    private ContactoDatabase db = new ContactoDatabase();
    private Contacto contacto;
    public DetalleContactoPage()
	{
		InitializeComponent();
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("contacto", out var contactoObj) && contactoObj is Contacto c)
        {
            contacto = c;

            // Asigna a los Entry los valores del contacto
            nombreEntry.Text = contacto.Nombre;
            telefonoEntry.Text = contacto.Telefono;
            correoEntry.Text = contacto.CorreoElectronico;
        }
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(nombreEntry.Text) ||
            string.IsNullOrWhiteSpace(telefonoEntry.Text) ||
            string.IsNullOrWhiteSpace(correoEntry.Text))
        {
            await DisplayAlert("Campos requeridos", "Todos los campos son obligatorios.", "OK");
            return;
        }

        contacto.Nombre = nombreEntry.Text;
        contacto.Telefono = telefonoEntry.Text;
        contacto.CorreoElectronico = correoEntry.Text;

        await db.GuardarContactoAsync(contacto);
        await Shell.Current.GoToAsync("..");
    }
}