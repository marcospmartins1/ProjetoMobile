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
	public partial class CFuncionarioPage : ContentPage
	{

        protected Funcionario funcionario = new Funcionario();
        public CFuncionarioPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCFuncionários_Clicked(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrEmpty(entryNomeFuncionario.Text) ||
                    string.IsNullOrEmpty(entryCPFFuncionario.Text) ||
                    string.IsNullOrEmpty(entryDataFuncionario.Text) ||
                    string.IsNullOrEmpty(entryEmailFuncionario.Text) ||
                    string.IsNullOrEmpty(entryTelefoneFuncionario.Text))
                {
                    DisplayAlert("Erro..", "Atençaõ! Não deixe os campos em brancos.", "OK");
                }
                else
                {
                    bool resultadoInsert = funcionario.Inserir(entryNomeFuncionario.Text, entryCPFFuncionario.Text, entryDataFuncionario.Text, pickerSexoFuncionario, entryEmailFuncionario.Text, entryTelefoneFuncionario.Text, pickerHorarioFuncionario);
                    if (resultadoInsert == true)
                    {
                        DisplayAlert("Sucesso!", "Funcionário cadastrado com sucesso.", "OK");
                        entryNomeFuncionario.Text = "";
                        entryCPFFuncionario.Text = "";
                        entryDataFuncionario.Text = "";
                        entryEmailFuncionario.Text = "";
                        entryTelefoneFuncionario.Text = "";

                        Navigation.PopAsync();
                    }
                    else
                    {
                        DisplayAlert("Ops...", "Houve um erro, tente novamente.", "OK");
                    }
                }
            }
        }

        private void BtnAFuncionários_Clicked(object sender, EventArgs e)
        {

        }
    }
}