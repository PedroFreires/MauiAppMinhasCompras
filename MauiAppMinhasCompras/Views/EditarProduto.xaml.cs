using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto /*Preenchendo a model*/
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

           await App.Db.Update(p); /*Quando usamos await a classe tem que ser async*/
           await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
           await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
           await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}