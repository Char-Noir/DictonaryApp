using DictonaryApp.DTO.Responce;
using DictonaryApp.Pages.Dicts;
using DictonaryApp.Pages.Learning;
using DictonaryApp.Pages.Words;

namespace DictonaryApp;

public partial class OneDictionaryPage : ContentPage
{
    public int IdDictionary { get; init; }
    public DictionaryResponceDTO OneDictionarie { get; set; } =new DictionaryResponceDTO();

    public OneDictionaryPage(int id)
	{
		InitializeComponent();
        IdDictionary = id;
        BindingContext = this;
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new DictionarySettingsPage(IdDictionary));
    }
    private async void OnDestAddToDictionaryClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddWordPage(IdDictionary));
    }
    private async void OnListWordsCLicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListWords(IdDictionary));
    }
    private async void OnLearningCLicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LearningPage(IdDictionary));
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
    }

}