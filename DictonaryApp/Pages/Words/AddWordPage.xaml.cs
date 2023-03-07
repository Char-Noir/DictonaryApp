using DictonaryApp.DTO.Responce;
using DictonaryApp.Translation;

namespace DictonaryApp.Pages.Words;

public partial class AddWordPage : ContentPage
{
    public int IdDictionary { get; init; }

    public DictionaryResponceDTO OneDictionarie { get; set; } = new DictionaryResponceDTO();
    public AddWordPage(int id)
	{
		InitializeComponent();
        IdDictionary = id;
        BindingContext = this;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        OneDictionarie = await App.DictionaryRepo.GetOneDictionary(IdDictionary);
        if (OneDictionarie.Name == null)
        {
            await Navigation.PopToRootAsync();
        }
        Title = OneDictionarie.Name;
        LanguageFrom.Text = TranslationLanguageManager.GetLanguageByCode(OneDictionarie.LanguageFrom).Name;
        LanguageTo.Text = TranslationLanguageManager.GetLanguageByCode(OneDictionarie.LanguageTo).Name;
        ErrorLine.Opacity = 0;
    }
    private async void OnCreateClicked(object sender, EventArgs e)
    {
        if(TextFrom.Text == string.Empty || TextTo.Text == string.Empty)
        {
            ErrorLine.Opacity = 1;
            return;
        }
        ErrorLine.Opacity = 0;
        var result = await App.DictionaryRepo.AddNewWordToDictionary(new DTO.Request.WordRequestDTO { TextTo = TextTo.Text, TextFrom = TextFrom.Text, IdDictionary = OneDictionarie.Id });
        if (result)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Alert", App.DictionaryRepo.StatusMessage, "ok");
        }
    }
}