using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppBarbearia.Classes;
using AppBarbearia.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBarbearia.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaPromocoes : ContentPage
	{

        protected Promocao promocao = new Promocao();
        public ListaPromocoes ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            CarregarInformacoes();
        }

        public void CarregarInformacoes()
        {
            var lista = promocao.SelectAll();
            listViewPromocoes.ItemsSource = lista;
        }

        private void MenuItemAtualizarPromocao_Clicked(object sender, EventArgs e)
        {

        }

        private async void MenuItemApagarPromocao_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Confirmação", "tem certeza que deseja deletar?", "SIM", "NÃO");
            if (resposta == true)
            {
                try
                {
                    var mi = (MenuItem)sender;
                    var model = (ModelPromocao)mi.CommandParameter;
                    var resultadoDeleteItem = promocao.DeleteItem(model.ID);

                    if (resultadoDeleteItem == true)
                    {
                        await DisplayAlert("Sucesso!", "Item Deletado", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Ops...", "Houve um erro", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERRO", ex.Message, "OK");
                }
            }
            CarregarInformacoes();
        }

        private async void MenuItemApagarTudoPromocao_Clicked(object sender, EventArgs e)
        {
            var respostaConfirmacao = await DisplayAlert("Confimação", "tem certeza que deseja deletar todas as informações?", "SIM", "NÃO");
            if (respostaConfirmacao == true)
            {
                try
                {
                    var resultadoDeleteAll = promocao.DeleteAll();

                    if (resultadoDeleteAll == true)
                    {
                        await DisplayAlert("Sucesso!", "Inserido", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Ops...", "Houve um erro", "OK");
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERRO", ex.Message, "OK");
                }
            }
            CarregarInformacoes();
        }

        private void ButtonAdicionarPromocao_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CPromocoesPage());
        }

        private void ButtonAtualizarListaPromocao_Clicked(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }
    }
}