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
	public partial class ListaServico : ContentPage
	{

        protected Servico servico = new Servico();
        public ListaServico ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            CarregarInformacoes();
        }

        public void CarregarInformacoes()
        {
            var lista = servico.SelectAll();
            listViewServicos.ItemsSource = lista;
        }

        private void MenuItemAtualizarServico_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CServicoPage());
        }

        private async void MenuItemApagarServico_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Confirmação", "tem certeza que deseja deletar?", "SIM", "NÃO");
            if (resposta == true)
            {
                try
                {
                    var mi = (MenuItem)sender;
                    var model = (ModelServico)mi.CommandParameter;
                    var resultadoDeleteItem = servico.DeleteItem(model.ID);

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

        private async void MenuItemApagarTudoServico_Clicked(object sender, EventArgs e)
        {
            var respostaConfirmacao = await DisplayAlert("Confimação", "tem certeza que deseja deletar todas as informações?", "SIM", "NÃO");
            if (respostaConfirmacao == true)
            {
                try
                {
                    var resultadoDeleteAll = servico.DeleteAll();

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

        private void ButtonAdicionarServico_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CServicoPage());
        }

        private void ButtonAtualizarListaServico_Clicked(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }

        private void ListViewServicos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CServicoPage());
        }
    }
}