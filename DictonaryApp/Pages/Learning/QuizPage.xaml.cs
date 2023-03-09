using DictonaryApp.Helpers;
using DictonaryApp.Models.LocalModels;
using DictonaryApp.Resources.Localization;
using DictonaryApp.Translation;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DictonaryApp.Pages.Learning;

public partial class QuizPage : ContentPage
{
	public int Score = 0;
    public int IdDictionary;
    public ObservableCollection<QuizItem> Qiuz = new ObservableCollection<QuizItem>();
    public int CurrentIndex = 0;
    public QuizPage(int id)
	{
        IdDictionary = id;
        InitializeComponent();
        Initialize();
        Qiuz.CollectionChanged += OnCollectionChanged;
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
        var languageFrom = TranslationLanguageManager.GetLanguageByCode(OneDictionary.LanguageFrom).Name;
        var languageTo = TranslationLanguageManager.GetLanguageByCode(OneDictionary.LanguageTo).Name;
        List<QuizItem> items = new();
        foreach (var word in words)
        {
            items.Add(new QuizItem { Answer = word.WordFrom, Question = word.WordTo, AnswerLanguage = languageFrom, QuestionLanguage = languageTo });
            items.Add(new QuizItem { Answer = word.WordTo, Question = word.WordFrom, AnswerLanguage = languageTo, QuestionLanguage = languageFrom });
        }

        items.Shuffle();

        items.ForEach(Qiuz.Add);
    }

    public void ShowWord()
    {
        if (Qiuz.Count <= 0)
        {
            return;
        }

        TextFrom.Text = Qiuz[CurrentIndex].Question;
        TextTo.Text = Qiuz[CurrentIndex].Answer;
        NextBtn.Opacity = 0;
    }

    private void OnAcceptClicked(object sender, EventArgs e)
    {
        Qiuz[CurrentIndex].IsAnsweredCorrectrly = true;
        NextBtn.Opacity = 1;
        if(CurrentIndex>=Qiuz.Count-1) {
            NextBtn.Text = AppRes.end_btn;
        }
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Qiuz[CurrentIndex].IsAnsweredCorrectrly = false;
        NextBtn.Opacity = 1;
        if (CurrentIndex >= Qiuz.Count - 1)
        {
            NextBtn.Text = AppRes.end_btn;
        }
    }
    private async void OnNextCLicked(object sender, EventArgs e)
    {
        var question = Qiuz[CurrentIndex];
        Score += question.IsAnsweredCorrectrly ? question.Score : 0;
        ScoreLabel.Text = String.Format(AppRes.score, Score);
        if (CurrentIndex >= Qiuz.Count - 1)
        {
            var maxScore = Qiuz.Select(x => x.Score).Sum();
            await DisplayAlert(AppRes.quiz_end, String.Format(AppRes.score_result, Score, maxScore), "Ok");
            return;
        }
        CurrentIndex++;
        NextBtn.Opacity = 0;
        ShowWord();
    }
}