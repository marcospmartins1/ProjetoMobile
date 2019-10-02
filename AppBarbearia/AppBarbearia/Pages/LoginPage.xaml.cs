using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppBarbearia.Pages;

namespace AppBarbearia
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnEsqueciSenha_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnNovaConta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CUsuarioPage());
        }

        private void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(entryUsuario.Text) ||
               string.IsNullOrEmpty(entrySenha.Text))
            {
                DisplayAlert("Erro..", "Não deixe os campos em branco!", "Tente novamente");
            }
            else if (entryUsuario.Text == "admin" && entrySenha.Text == "admin")
            {
                Navigation.PushAsync(new MenuPage());
            }
            else
            {
                DisplayAlert("Erro..", "Usuário ou senha incorretos!", "Tente novamente");
            }
        }
    }
}
