

using DictonaryApp.Repositories;

namespace DictonaryApp;

public partial class App : Application
{
    public static DictionaryRepository DictionaryRepo { get; private set; }
    public App(DictionaryRepository repo)
	{
		InitializeComponent();
        DictionaryRepo = repo;
        MainPage = new NavigationPage(new MainPage());
    }


}
