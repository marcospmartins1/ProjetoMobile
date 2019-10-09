using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppBarbearia.Classes;
using AppBarbearia.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBarbearia.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Usuario2Page : ContentPage
    {
        protected Usuario usuario = new Usuario();
        public Usuario2Page()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCUsuario2_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(entryNomeUsuario2.Text) ||
                string.IsNullOrEmpty(entrySenhaUsuario2.Text) ||
                string.IsNullOrEmpty(entryEmailUsuario2.Text))
            {
                DisplayAlert("Erro..", "Atençaõ! Não deixe os campos em brancos.", "OK");
            }
            else if (entrySenhaUsuario2.Text == entryConfirmaSenhaUsuario2.Text)
            {
                bool resultadoInsert = usuario.Inserir(entryNomeUsuario2.Text, entrySenhaUsuario2.Text, entryEmailUsuario2.Text);
                if (resultadoInsert == true)
                {
                    DisplayAlert("Sucesso!", "Usuário registrado com sucesso.", "OK");
                    entryNomeUsuario2.Text = "";
                    entrySenhaUsuario2.Text = "";
                    entryEmailUsuario2.Text = "";

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

        private void BtnLimparUsuario2_Clicked(object sender, EventArgs e)
        {
            entryNomeUsuario2.Text = "";
            entrySenhaUsuario2.Text = "";
            entryEmailUsuario2.Text = "";
        }
    }
}