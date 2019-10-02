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
	public partial class MenuPage : MasterDetailPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            Detail = new NavigationPage(new PrincipalPage());
        }

        private void PaginaCliente_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CClientePage());
            IsPresented = false;
        }

        private void PaginaFuncionario_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CFuncionarioPage());
            IsPresented = false;
        }

        private void PaginaPromocao_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CPromocoesPage());
            IsPresented = false;
        }

        private void PaginaServico_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CServicoPage());
            IsPresented = false;
        }

        private void PaginaUsuario_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CUsuarioPage());
            IsPresented = false;
        }

        private void PaginaSobre_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Sobre());
            IsPresented = false;
        }

        private void PaginaAgendamento_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AgendamentoPage());
            IsPresented = false;
        }

        private void PaginaPrincipal_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PrincipalPage());
            IsPresented = false;
        }

        private void PaginaSobre1_Tapped(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SobreAplicativoPage());
            IsPresented = false;
        }
    }
}