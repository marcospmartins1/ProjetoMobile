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
	public partial class CClientePage : ContentPage
	{

        protected Cliente cliente = new Cliente();
        public CClientePage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCCliente_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryNome.Text) ||
                string.IsNullOrEmpty(entryCPF.Text) ||
                string.IsNullOrEmpty(entryData.Text) ||
                string.IsNullOrEmpty(entryEmail.Text) ||
                string.IsNullOrEmpty(entryTelefone.Text) ||
                string.IsNullOrEmpty(entryObservacao.Text))
            {
                DisplayAlert("Erro..", "Atençaõ! Não deixe os campos em brancos.", "OK");
            }
            else
            {
                bool resultadoInsert = cliente.Inserir(entryNome.Text, entryCPF.Text, entryData.Text, pickerSexo, entryEmail.Text, entryTelefone.Text, entryObservacao.Text);
                if (resultadoInsert == true)
                {
                    DisplayAlert("Sucesso!", "Cliente cadastrado com sucesso.", "OK");
                    entryNome.Text = "";
                    entryCPF.Text = "";
                    entryData.Text = "";
                    entryEmail.Text = "";
                    entryTelefone.Text = "";
                    entryObservacao.Text = "";

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Ops...", "Houve um erro, tente novamente.", "OK");
                }
            }
        }

    }
}