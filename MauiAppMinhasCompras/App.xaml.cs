using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db; /*Declarando um campo estático*/

        public static SQLiteDatabaseHelper Db /*Tornando o campo _db publico*/
        {
            get /*O método será apenas de leitura*/
            {
                if(_db == null) /*se não tiver um objeto no meu campo db o app instancia*/
                {
                    string path = Path.Combine( /*Buscando o local do SQLite*/
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }


        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }


    }
}