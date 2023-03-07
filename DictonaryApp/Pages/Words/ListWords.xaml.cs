using DictonaryApp.DTO.Responce;

namespace DictonaryApp.Pages.Words;

public partial class ListWords : ContentPage
{
	public int IdDictionary { get; set; }
    List<WordResponceDTO> Words = new List<WordResponceDTO>();
    public ListWords(int id)
	{
		InitializeComponent();
		IdDictionary = id;

    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<WordResponceDTO> words = await App.DictionaryRepo.GetAllWordsByDictionary(IdDictionary);
        wordsList.ItemsSource = words;
        Words = words;
    }
    private async void OnWordOpenClick(object sender, EventArgs e)
    {
        Button button = sender as Button;
        var item = (WordResponceDTO)button.BindingContext;
        await Navigation.PushAsync(new OneWordPage(item.Id));
    }
}