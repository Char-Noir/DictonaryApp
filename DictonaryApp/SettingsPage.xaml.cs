using DictonaryApp.Resources.Localization;
using System.Globalization;

namespace DictonaryApp;

public partial class SettingsPage : ContentPage
{
    public LocalizationResourceManager LocalizationResourceManager { get; }
    public IList<Language> Languages { get; init; } 
    public SettingsPage()
	{
        InitializeComponent();
        Languages = LanguageManager. AvaliableLanguages;
        this.BindingContext = this;
        string languageCode = LanguageManager.AvaliableLanguages[0].Code;
        if (Preferences.ContainsKey("App.Language"))
        {
            languageCode = Preferences.Get("App.Language", LanguageManager.AvaliableLanguages[0].Code);
        }
        else
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
            languageCode = currentCulture.TwoLetterISOLanguageName;
        }
       
        LanguagePicker.SelectedIndex = LanguageManager.GetLanguageIndex(languageCode);
        LocalizationResourceManager = LocalizationResourceManager.Instance;
    }
    private void LanguageChanged(object sender, EventArgs e)
    {
        string language = Languages[LanguagePicker.SelectedIndex].Code;
        LocalizationResourceManager.Instance.SetCulture(new CultureInfo(language));
        Preferences.Set("App.Language", language);
    }
    
}