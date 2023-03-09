using DictonaryApp.DTO.Responce;
using DictonaryApp.Resources.Localization;
using DictonaryApp.Translation;

namespace DictonaryApp.Pages.Words;

public partial class OneWordPage : ContentPage
{
    public int IdWord { get; init; }
    public WordResponceDTO OneWord { get; set; } = new WordResponceDTO();
    public OneWordPage(int id)
	{
		InitializeComponent();
        IdWord = id;
        ErrorLine.Opacity = 0;

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        OneWord = await App.DictionaryRepo.GetOneWord(IdWord);
        if (OneWord.WordTo == null)
        {
            await Navigation.PopToRootAsync();
        }
        var OneDictionary = await App.DictionaryRepo.GetOneDictionary(OneWord.IdDictionary);
        TextFrom.Text = OneWord.WordFrom;
        TextTo.Text = OneWord.WordTo;
        ErrorLine.Opacity = 0;
        LanguageFrom.Text = TranslationLanguageManager.GetLanguageByCode(OneDictionary.LanguageFrom).Name;
        LanguageTo.Text = TranslationLanguageManager.GetLanguageByCode(OneDictionary.LanguageTo).Name;
    }
    private async void OnEditClicked(object sender, EventArgs e)
    {
        if (TextFrom.Text == string.Empty || TextTo.Text == string.Empty)
        {
            ErrorLine.Opacity = 1;
            return;
        }
        ErrorLine.Opacity = 0;
        var result = await App.DictionaryRepo.EditWordToDictionary(IdWord, new DTO.Request.WordRequestDTO { TextTo = TextTo.Text, TextFrom = TextFrom.Text });
        if (result)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Alert", App.DictionaryRepo.StatusMessage, "ok");
        }
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert(AppRes.Delete_dict, AppRes.Delete_Dict_question, AppRes.Yes, AppRes.No);
        if (!answer)
        {
            return;
        }

        App.DictionaryRepo.DeleteWord(IdWord);
        await Navigation.PopAsync();

    }
       
}