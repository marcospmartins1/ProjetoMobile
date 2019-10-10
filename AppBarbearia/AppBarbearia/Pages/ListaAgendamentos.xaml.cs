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
	public partial class ListaAgendamentos : ContentPage
	{

        protected Agendamento agendamento = new Agendamento();
        public ListaAgendamentos ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            CarregarInformacoes();
        }

        public void CarregarInformacoes()
        {
            var lista = agendamento.SelectAll();
            listViewAgendamentos.ItemsSource = lista;
        }

        private void MenuItemAtualizarAgendamento_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoPage());
        }

        private async void MenuItemApagarAgendamento_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Confirmação", "tem certeza que deseja deletar?", "SIM", "NÃO");
            if (resposta == true)
            {
                try
                {
                    var mi = (MenuItem)sender;
                    var model = (ModelAgendamento)mi.CommandParameter;
                    var resultadoDeleteItem = agendamento.DeleteItem(model.ID);

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

        private async void MenuItemApagarTudoAgendamento_Clicked(object sender, EventArgs e)
        {
            var respostaConfirmacao = await DisplayAlert("Confimação", "tem certeza que deseja deletar todas as informações?", "SIM", "NÃO");
            if (respostaConfirmacao == true)
            {
                try
                {
                    var resultadoDeleteAll = agendamento.DeleteAll();

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

        private void ButtonAdicionarAgendamento_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoPage());
        }

        private void ButtonAtualizarListaAgendamento_Clicked(object sender, EventArgs e)
        {
            CarregarInformacoes();
        }

        private void ListViewAgendamentos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new AgendamentoPage());
        }
    }
}