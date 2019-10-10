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
	public partial class ListaFuncionario : ContentPage
	{

        protected Funcionario funcionario = new Funcionario();
        public ListaFuncionario ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            CarregarInformacoes();
        }

        public void CarregarInformacoes()
        {
            var lista = funcionario.SelectAll();
            listViewFuncionario.ItemsSource = lista;
        }

        private void MenuItemAtualizarFuncionario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CFuncionarioPage());
        }

        private async void MenuItemApagarFuncionario_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Confirmação", "tem certeza que deseja deletar?", "SIM", "NÃO");
            if (resposta == true)
            {
                try
                {
                    var mi = (MenuItem)sender;
                    var model = (ModelFuncionario)mi.CommandParameter;
                    var resultadoDeleteItem = funcionario.DeleteItem(model.ID);

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

        private async void MenuItemApagarTudoFuncionario_Clicked(object sender, EventArgs e)
        {
            var respostaConfirmacao = await DisplayAlert("Confimação", "tem certeza que deseja deletar todas as informações?", "SIM", "NÃO");
            if (respostaConfirmacao == true)
            {
                try
                {
                    var resultadoDeleteAll = funcionario.DeleteAll();

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

        private void ButtonAdicionarFuncionario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CFuncionarioPage());
        }

        private void ButtonAtualizarListaFuncionario_Clicked(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }

        private void ListViewFuncionario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new CFuncionarioPage());
        }
    }
}