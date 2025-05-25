using AgendaPersonal.Modelos;
using AgendaPersonal.Datos;
using AgendaPersonal.Utils;

namespace AgendaPersonal.Views;

public partial class ContactosPage : ContentPage
{
    private ContactoDatabase db = new ContactoDatabase();
    public ContactosPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        contactosView.ItemsSource = await db.ObtenerContactosAsync();
    }

    private async void OnContactoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Contacto seleccionado)
        {
            var navParameter = new Dictionary<string, object>
        {
            { "contacto", seleccionado }
        };
            await Shell.Current.GoToAsync("detallecontacto", navParameter);
        }
    }

    private async void OnEliminarContacto(object sender, EventArgs e)
    {
        if (((SwipeItem)sender).BindingContext is Contacto contacto)
        {
            bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {contacto.Nombre}?", "Sí", "No");
            if (confirm)
            {

                await db.EliminarContactoAsync(contacto);
                contactosView.ItemsSource = await db.ObtenerContactosAsync();
            }
        }
    }
}