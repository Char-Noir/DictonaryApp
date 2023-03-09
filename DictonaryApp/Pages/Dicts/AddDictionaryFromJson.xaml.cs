using DictonaryApp.DTO.Request;
using DictonaryApp.Helpers;

namespace DictonaryApp.Pages.Dicts;

public partial class AddDictionaryFromJson : ContentPage
{
	public AddDictionaryFromJson()
	{
		InitializeComponent();
	}
	private async void OnCreateClicked(object sender, EventArgs e)
	{
		var dict = JsonHelper.Deserialize(DictText.Text);
		DictionaryRequestDTO dictionary = new DictionaryRequestDTO { Name = dict.Name, LanguageFrom = dict.LanguageFrom, LanguageTo = dict.LanguageTo };
		List<WordRequestDTO> words = dict.Words.Select(x=>new WordRequestDTO { TextFrom = x.FromWord, TextTo = x.ToWord }).ToList();
		App.DictionaryRepo.AddDictionaryFromJson(dictionary, words);
		await Navigation.PopToRootAsync();
	}
}