using DictonaryApp.DTO.Responce;
using DictonaryApp.Resources.Localization;
using DictonaryApp.Translation;
using Microsoft.Maui.Controls.Platform;
using System.Collections;
using static DictonaryApp.Helpers.JsonHelper;

namespace DictonaryApp.Pages.Dicts;

public partial class DictionarySettingsPage : ContentPage
{
    public IList<ComplexLanguage> Languages { get; init; }
    public int IdDictionary { get; init; }
    public DictionaryResponceDTO OneDictionarie { get; set; } = new DictionaryResponceDTO();
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        OneDictionarie = await App.DictionaryRepo.GetOneDictionary(IdDictionary);
        dictionaryName.Text = OneDictionarie.Name;
        LanguageTo.SelectedIndex = TranslationLanguageManager.AvaliableLanguages.IndexOf(TranslationLanguageManager.GetLanguageByCode(OneDictionarie.LanguageTo));
        LanguageFrom.SelectedIndex = TranslationLanguageManager.AvaliableLanguages.IndexOf(TranslationLanguageManager.GetLanguageByCode(OneDictionarie.LanguageFrom));
        
    }
    public DictionarySettingsPage(int id)
	{
		InitializeComponent();
        IdDictionary = id;
        Languages = TranslationLanguageManager.AvaliableLanguages;
        this.BindingContext = this;
        ErrorLine.Opacity = 0;
    }
    private void LanguageChanged(object sender, EventArgs e)
    {
        string languageTo = Languages[((LanguageTo.SelectedIndex >= 0) ? LanguageTo.SelectedIndex : 0)].Code;
        string languageFrom = Languages[((LanguageFrom.SelectedIndex >= 0) ? LanguageFrom.SelectedIndex : 0)].Code;
        if (languageTo == languageFrom)
        {
            ErrorLine.Opacity = 1;
        }
        else
        {
            ErrorLine.Opacity = 0;
        }
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {

        string languageTo = Languages[LanguageTo.SelectedIndex].Code;
        string languageFrom = Languages[LanguageFrom.SelectedIndex].Code;
        if (languageTo == languageFrom)
        {
            return;
        }
        string name = dictionaryName.Text;
        if (name.Length <= 0)
        {
            name = "dummy";
        }
        if (name.Length > 32)
        {
            await DisplayAlert("Alert", "Very long string", "OK");
            return;
        }
        bool result = await App.DictionaryRepo.UpdateDictionary(IdDictionary,new DTO.Request.DictionaryRequestDTO { Name = name, LanguageFrom = languageFrom, LanguageTo = languageTo });
        if (!result)
        {
            await DisplayAlert("Alert", App.DictionaryRepo.StatusMessage, "OK");
            return;
        }
        await Navigation.PopModalAsync();
    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        
        if (dictionaryName.Text != OneDictionarie.Name || Languages[LanguageTo.SelectedIndex].Code != OneDictionarie.LanguageTo || Languages[LanguageFrom.SelectedIndex].Code != OneDictionarie.LanguageFrom)
        {
            bool answer  = await DisplayAlert(AppRes.Back, AppRes.Back_question, AppRes.Yes, AppRes.No);
            if(!answer)
            {
                return;
            }
            await Navigation.PopModalAsync();
        }
        
        await Navigation.PopModalAsync();
    }
    private async void OnJsonClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ShowJsonPage(IdDictionary));
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {

         bool answer = await DisplayAlert(AppRes.Delete_dict, AppRes.Delete_Word_question, AppRes.Yes, AppRes.No);
            if (!answer)
            {
                return;
           }
        
        App.DictionaryRepo.DeleteDict(IdDictionary);
        await Navigation.PopToRootAsync();
        await Navigation.PopModalAsync();
        
    }
}