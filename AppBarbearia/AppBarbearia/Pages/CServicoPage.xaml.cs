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
	public partial class CServicoPage : ContentPage
	{

        protected Servico servico = new Servico();
        public CServicoPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCServicos_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryNomeServico.Text) ||
                string.IsNullOrEmpty(entryDescricaoServico.Text) ||
                string.IsNullOrEmpty(entryValorServico.Text))
            {
                DisplayAlert("Erro..", "Atençaõ! Não deixe os campos em brancos.", "OK");
            }
            else
            {
                bool resultadoInsert = servico.Inserir(pickerStatusServico, entryNomeServico.Text, entryDescricaoServico.Text, pickerTempoPromocao, entryValorServico.Text);
                if (resultadoInsert == true)
                {
                    DisplayAlert("Sucesso!", "Serviço cadastrado com sucesso.", "OK");
                    entryNomeServico.Text = "";
                    entryDescricaoServico.Text = "";
                    entryValorServico.Text = "";

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Ops...", "Houve um erro, tente novamente.", "OK");
                }
            }
        }

        private void BtnAServicos_Clicked(object sender, EventArgs e)
        {

        }
    }
}