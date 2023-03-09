using DictonaryApp.DTO.Responce;
using DictonaryApp.Translation;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DictonaryApp.Pages.Learning;

public partial class LearningPage : ContentPage
{
	public int IdDictionary;
    public ObservableCollection<WordResponceDTO> Words = new ObservableCollection<WordResponceDTO>();
    public int CurrentIndex = 0;

    public LearningPage(int id)
	{
        IdDictionary = id;
        InitializeComponent();
		RightBtn.RotateTo(180.0d);
        Initialize();
        Words.CollectionChanged += OnCollectionChanged;
    }
    void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            ShowWord();
        }

       
    }
    public async void Initialize()
    {
        var words = await App.DictionaryRepo.GetAllWordsByDictionary(IdDictionary);
        var OneDictionary = await App.DictionaryRepo.GetOneDictionary(IdDictionary);
        LanguageFrom.Text = TranslationLanguageManager.GetLanguageByCode(OneDictionary.LanguageFrom).Name;
        LanguageTo.Text = TranslationLanguageManager.GetLanguageByCode(OneDictionary.LanguageTo).Name;
        words.ForEach(Words.Add);
    }

    public void ShowWord()
    {
        if (Words.Count <= 0)
        {
            return;
        }
        TextFrom.Text = Words[CurrentIndex].WordFrom;
        TextTo.Text = Words[CurrentIndex].WordTo;
        LeftBtn.IsEnabled = CurrentIndex>0;
        RightBtn.IsEnabled = CurrentIndex<Words.Count-1;
    }

	private async void OnLeftClicked(object sender, EventArgs e)
	{
        CurrentIndex--;
        ShowWord();
	}
    private async void OnRightClicked(object sender, EventArgs e)
    {
        CurrentIndex++;
        ShowWord();
    }
    
}