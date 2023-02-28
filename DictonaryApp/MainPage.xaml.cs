namespace DictonaryApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		count = Preferences.Get("MainPage.number_count", 0);
		InitializeComponent();
        UpdateClickMeButtonText();
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
        Preferences.Set("MainPage.number_count", count);
        UpdateClickMeButtonText();
    }

	private void UpdateClickMeButtonText()
	{
        if (count == 0)
            CounterBtn.Text = "Click me";
        else if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

