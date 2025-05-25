namespace AgendaPersonal.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (await isAuthenticated())
        {
            await Shell.Current.GoToAsync("///main");
        }
        else
        {
            await Shell.Current.GoToAsync("///login");
        }
    }

    async Task<bool> isAuthenticated()
    {
        await Task.Delay(2000);
        var hasAuth = await SecureStorage.GetAsync("hasAuth");
        return hasAuth == "true";
    }
}