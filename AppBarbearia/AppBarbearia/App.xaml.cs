using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBarbearia.Pages;

using PCLExt.FileStorage.Folders;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppBarbearia
{
    public partial class App : Application
    {

        public SQLite.SQLiteConnection Conexao { get; private set; }
        public App()
        {
            var pasta = new LocalRootFolder();

            var arquivo = pasta.CreateFile("banco.db", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            Conexao = new SQLite.SQLiteConnection(arquivo.Path);

            Conexao.Execute("CREATE TABLE IF NOT EXISTS cliente (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, nome_cliente TEXT (255) NOT NULL, cpf BIGINTEGER NOT NULL, data_nascimento TEXT (15) NOT NULL, sexo TEXT (15) NOT NULL, email TEXT (255) NOT NULL, telefone_celular INTEGER (15) NOT NULL, observacao TEXT (255) NOT NULL)");
            Conexao.Execute("CREATE TABLE IF NOT EXISTS funcionario (ID INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, nome_funcionario TEXT (255) NOT NULL, cpf BIGINTEGER NOT NULL, data_nascimento TEXT (15) NOT NULL, sexo TEXT (15) NOT NULL, email TEXT (255) NOT NULL, telefone_celular INTEGER (15) NOT NULL, horario_atendimento TEXT (255) NOT NULL)");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
