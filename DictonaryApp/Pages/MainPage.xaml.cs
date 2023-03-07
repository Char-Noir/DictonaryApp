using DictonaryApp.DTO.Request;
using DictonaryApp.DTO.Responce;
using DictonaryApp.Resources.Localization;
using System.Globalization;
using System.Windows.Input;

namespace DictonaryApp;

public partial class MainPage : ContentPage
{

    List<DictionaryResponceDTO> Dictionaries = new List<DictionaryResponceDTO>();
   
    public MainPage()
	{
		InitializeComponent();
       
        if (Preferences.ContainsKey("App.Language") && Preferences.Get("App.Language", LanguageManager.AvaliableLanguages[0].Code) != Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName)
        {
            LocalizationResourceManager.Instance.SetCulture(new CultureInfo(Preferences.Get("App.Language", LanguageManager.AvaliableLanguages[0].Code)));
        }

    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<DictionaryResponceDTO> dictionaries =  await App.DictionaryRepo.GetAllDictionaries();  
        dictionaryList.ItemsSource = dictionaries;
        Dictionaries = dictionaries;
    }

    

    private async void OnDestSettingsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }
    private async void OnDictOpenClick(object sender, EventArgs e)
    {
        Button button = sender as Button;
        var item = (DictionaryResponceDTO)button.BindingContext;
        await Navigation.PushAsync(new OneDictionaryPage(item.Id));
    }
    private async void OnDestAddDictionaryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddDictionary());
    }

    
    
}

