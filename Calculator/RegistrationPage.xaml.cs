namespace Calculator;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage()
	{
		InitializeComponent();
	}
    private void OkClicked(object sender, EventArgs e)
    {
        // kay�t i�lemleri yap�ld�...
        Navigation.PopAsync();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        // hi� bir i�lem yapmadan geri d�n...
        Navigation.PopAsync();
    }
}