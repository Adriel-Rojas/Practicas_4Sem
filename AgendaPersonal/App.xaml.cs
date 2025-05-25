#if __ANDROID__
using Android.Content.Res;

using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using AgendaPersonal.Utils;

#endif
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Platform;
using AgendaPersonal.Utils;
using AgendaPersonal.Views;


namespace AgendaPersonal;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new NavigationPage(new MainPage());

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderLine", (handler, view) =>
        {
#if __ANDROID__
            (handler.PlatformView as Android.Views.View).SetBackgroundColor(Microsoft.Maui.Graphics.Colors.Transparent.ToAndroid());
#endif
        });
    }
    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Aplicar tema guardado al iniciar
        bool esOscuro = ConfiguracionApp.ObtenerTema();
        UserAppTheme = esOscuro ? AppTheme.Dark : AppTheme.Light;

        return new Window(MainPage);



    }
}
