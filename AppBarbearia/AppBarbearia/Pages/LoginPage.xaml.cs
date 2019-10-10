using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppBarbearia.Pages;

using AppBarbearia.Classes;

namespace AppBarbearia
{
    public partial class MainPage : ContentPage
    {

        protected Usuario usuario = new Usuario();
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
            Navigation.PushAsync(new Usuario2Page());
        }

        private void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryUsuario.Text) ||
                string.IsNullOrEmpty(entrySenha.Text))
            {
                DisplayAlert("Erro..", "Não deixe os campos em branco!", "Tente novamente");
            }
            else
            {
                bool resultadoLogin = usuario.Login(entryUsuario.Text, entrySenha.Text);
                if (resultadoLogin == true)
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
}
