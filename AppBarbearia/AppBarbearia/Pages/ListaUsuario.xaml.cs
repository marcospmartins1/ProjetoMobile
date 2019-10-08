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
	public partial class ListaUsuario : ContentPage
	{
        protected Usuario usuario = new Usuario();
        public ListaUsuario ()
		{
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CarregarInformacoes();
        }

        public void CarregarInformacoes()
        {
            var lista = usuario.SelectAll();
            listViewUsuario.ItemsSource = lista;
        }

        private void MenuItemAtualizarUsuario_Clicked(object sender, EventArgs e)
        {

        }

        private async void MenuItemApagarServicoUsuario_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Confirmação", "tem certeza que deseja deletar?", "SIM", "NÃO");
            if (resposta == true)
            {
                try
                {
                    var mi = (MenuItem)sender;
                    var model = (ModelUsuario)mi.CommandParameter;
                    var resultadoDeleteItem = usuario.DeleteItem(model.ID);

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

        private async void MenuItemApagarTudoUsuario_Clicked(object sender, EventArgs e)
        {
            var respostaConfirmacao = await DisplayAlert("Confimação", "tem certeza que deseja deletar todas as informações?", "SIM", "NÃO");
            if (respostaConfirmacao == true)
            {
                try
                {
                    var resultadoDeleteAll = usuario.DeleteAll();

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

        private void ButtonAdicionarUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CUsuarioPage());
        }

        private void ButtonAtualizarListaUsuario_Clicked(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }
    }
}