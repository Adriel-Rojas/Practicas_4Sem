using AgendaPersonal.Views;

namespace AgendaPersonal;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //Register all routes
        Routing.RegisterRoute("loading", typeof(LoadingPage));
        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("main", typeof(MainPage));
        Routing.RegisterRoute("configuracion", typeof(ConfiguracionPage));
        Routing.RegisterRoute("crearcontacto", typeof(CrearContactoPage));
        Routing.RegisterRoute("detallecontacto", typeof(DetalleContactoPage));
        Routing.RegisterRoute("registro", typeof(RegistroPage));
        Routing.RegisterRoute("recuperar", typeof(RecuperarPage));
    }
}
