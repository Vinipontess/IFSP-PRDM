namespace TP1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

     <summary>
     </summary>
	private void OnOkButtonClicked(object sender, EventArgs e)
    {
        if (IdEntry.Text == "admin" && PassEntry.Text == "senha@dmin")
        {
            DisplayAlert("Login", "Logou com sucesso", "OK");
        }
        else
        {
            DisplayAlert("Login", "Login inválido, não autorizado", "OK");
        }
    }

     <summary>
     </summary>
	private void OnLimparButtonClicked(object sender, EventArgs e)
    {
        IdEntry.Text = string.Empty;
        PassEntry.Text = string.Empty;

        IdEntry.Focus();
    }

     <summary>
     </summary> 
	private async void OnCreditosButtonClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Créditos", "Desenvolvido por:\n\n- Vinícius Pontes\n- Eduardo Barbosa", "Fechar");
    }
}