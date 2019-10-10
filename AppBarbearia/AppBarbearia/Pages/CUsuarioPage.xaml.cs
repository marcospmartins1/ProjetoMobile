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
	public partial class CUsuarioPage : ContentPage
	{

        protected Usuario usuario = new Usuario();
        public CUsuarioPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCUsuario_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryNomeUsuario.Text) ||
                string.IsNullOrEmpty(entrySenhaUsuario.Text) ||
                string.IsNullOrEmpty(entryEmailUsuario.Text))
            {
                DisplayAlert("Erro..", "Atençaõ! Não deixe os campos em brancos.", "OK");
            }
            else if (entrySenhaUsuario.Text == entryConfirmaSenhaUsuario.Text)
            {
                bool resultadoInsert = usuario.Inserir(entryNomeUsuario.Text, entrySenhaUsuario.Text, entryEmailUsuario.Text);
                if (resultadoInsert == true)
                {
                    DisplayAlert("Sucesso!", "Usuário cadastrado com sucesso.", "OK");
                    entryNomeUsuario.Text = "";
                    entrySenhaUsuario.Text = "";
                    entryEmailUsuario.Text = "";

                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Ops...", "Houve um erro, tente novamente.", "OK");
                }
            }
            else
            {
                DisplayAlert("Erro..", "Senhas não conferem.", "Tente novamente");
            }
        }

        private void BtnAUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}