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
	public partial class CPromocoesPage : ContentPage
	{

        protected Promocao promocao = new Promocao();
        public CPromocoesPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCPromoções_Clicked(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrEmpty(entryNomePromocao.Text) ||
                    string.IsNullOrEmpty(entryDescricaoPromocao.Text) ||
                    string.IsNullOrEmpty(entryValorPromocao.Text))
                {
                    DisplayAlert("Erro..", "Atençaõ! Não deixe os campos em brancos.", "OK");
                }
                else
                {
                    bool resultadoInsert = promocao.Inserir(pickerStatusPromocao, entryNomePromocao.Text, entryDescricaoPromocao.Text, pickerTempoPromocao, entryValorPromocao.Text);
                    if (resultadoInsert == true)
                    {
                        DisplayAlert("Sucesso!", "Promoção cadastrado com sucesso.", "OK");
                        entryNomePromocao.Text = "";
                        entryDescricaoPromocao.Text = "";
                        entryValorPromocao.Text = "";

                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Ops...", "Houve um erro, tente novamente.", "OK");
                    }
                }
            }
        }

        private void BtnAPromoções_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}