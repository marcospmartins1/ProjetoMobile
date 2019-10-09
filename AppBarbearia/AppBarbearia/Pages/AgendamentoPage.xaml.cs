using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppBarbearia.Classes;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBarbearia.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgendamentoPage : ContentPage
	{

        protected Agendamento agendamento = new Agendamento();
        public AgendamentoPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCAgendamento_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryNomeClienteA.Text) ||
                string.IsNullOrEmpty(entryServicoA.Text))
            {
                DisplayAlert("Erro..", "Atençaõ! Não deixe os campos em brancos.", "OK");
            }
            else
            {
                bool resultadoInsert = agendamento.Inserir(entryNomeClienteA.Text, entryNomeFuncionarioA.Text, entryServicoA.Text, PickerTimerAgendamento, pickerDuracaoAgendamento, DatePickerData);
                if (resultadoInsert == true)
                {
                    DisplayAlert("Sucesso!", "Serviço cadastrado com sucesso.", "OK");
                    entryNomeClienteA.Text = "";
                    entryNomeFuncionarioA.Text = "";
                    entryServicoA.Text = "";

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Ops...", "Houve um erro, tente novamente.", "OK");
                }
            }
        }

        private void BtnLAgendamento_Clicked(object sender, EventArgs e)
        {

        }
    }
}