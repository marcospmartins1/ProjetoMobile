using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBarbearia.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PrincipalPage : ContentPage
	{
		public PrincipalPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCliente_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaCliente());
        }

        private void BtnFuncionario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaFuncionario());
        }

        private void BtnPromocao_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaPromocoes());
        }

        private void BtnAgendar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaAgendamentos());
        }

        private void BtnServico_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaServico());
        }
    }
}