namespace Calculator;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}
    private void OkClicked(object sender, EventArgs e)
    {
        // kayýt iþlemleri yapýldý...
        Navigation.PopAsync();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        // hiç bir iþlem yapmadan geri dön...
        Navigation.PopAsync();
    }
}