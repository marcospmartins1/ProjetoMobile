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
	public partial class CUsuarioPage : ContentPage
	{
		public CUsuarioPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCUsuario_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnLimparUsuario_Clicked(object sender, EventArgs e)
        {

        }
    }
}