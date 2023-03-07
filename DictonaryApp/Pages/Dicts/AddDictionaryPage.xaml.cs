using DictonaryApp.Translation;
using System.Globalization;

namespace DictonaryApp;

public partial class AddDictionary : ContentPage
{
    public IList<ComplexLanguage> Languages { get; init; }
    public AddDictionary()
	{
        Languages = TranslationLanguageManager.AvaliableLanguages;
        InitializeComponent();
        this.BindingContext = this;
        LanguageTo.SelectedIndex = 5;
        LanguageFrom.SelectedIndex = 28;
        ErrorLine.Opacity = 0;
    }

    private void LanguageChanged(object sender, EventArgs e)
    {        
        string languageTo = Languages[((LanguageTo.SelectedIndex>=0)? LanguageTo.SelectedIndex : 0)].Code;
        string languageFrom = Languages[((LanguageFrom.SelectedIndex >= 0) ? LanguageFrom.SelectedIndex : 0)].Code;
        if (languageTo == languageFrom) {
            ErrorLine.Opacity = 1;
        }
        else
        {
            ErrorLine.Opacity = 0;
        }
    }

    private async void OnCreateClicked(object sender, EventArgs e)
    {
        
        string languageTo = Languages[LanguageTo.SelectedIndex].Code;
        string languageFrom = Languages[LanguageFrom.SelectedIndex].Code;
        if(languageTo == languageFrom)
        {
            return;
        }
        string name = dictionaryName.Text;
        if(name == null || name.Length <=0 )
        {
            name = dictionaryName.Placeholder;
        }
        if(name.Length > 32)
        {
            await DisplayAlert("Alert", "Very long string", "OK");
            return;
        }
        bool result = await App.DictionaryRepo.AddNewDictionary(new DTO.Request.DictionaryRequestDTO { Name = name, LanguageFrom = languageFrom, LanguageTo =  languageTo});
        if (!result)
        {
            await DisplayAlert("Alert", App.DictionaryRepo.StatusMessage, "OK");
            return;
        }
        await Navigation.PopAsync();
    }
}