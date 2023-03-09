using DictonaryApp.Helpers;
using static DictonaryApp.Helpers.JsonHelper;

namespace DictonaryApp.Pages.Dicts;

public partial class ShowJsonPage : ContentPage
{
	public ShowJsonPage(int id)
	{
		InitializeComponent();
		Initialize(id);
	}
    public string Text = "";
	private async void Initialize(int id)
	{
        var OneDictionarie = await App.DictionaryRepo.GetOneDictionary(id);
        var dict = new DictionaryJson { Name = OneDictionarie.Name, LanguageFrom = OneDictionarie.LanguageFrom, LanguageTo = OneDictionarie.LanguageTo };
        var words = await App.DictionaryRepo.GetAllWordsByDictionary(id);
        dict.Words = words.Select(x => new WordJson { FromWord = x.WordFrom, ToWord = x.WordTo }).ToList();
        Text = Serialize(dict);
        DictText.Text = Text;
    }
    private async void SetClipboardButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(Text);
        await Navigation.PopModalAsync();
    }
}