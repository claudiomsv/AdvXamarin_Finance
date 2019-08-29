using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Finance.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Finance
{
    public partial class App : Application
    {

        // MASTERCLASS - O CONSTRUTOR EH O PRIMEIRO METODO CHAMADO DESSA CLASSE DURANTE A INICILIAZACAO
        // ERROS AQUI NAO SERAO LANCADOS NO APPCENTER
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            // MASTERCLASS - app secrets vem do appcenter
            // segundo parametro do metodo start é o tipo de informação a ser salva

            string androidAppSecret = "c3bfd10b-c1de-414d-97bc-97fe2c0f9a26";
            string iosAppSecret = "57fcf921-5ad5-4baa-84e7-8352b660e765";
            AppCenter.Start($"android={androidAppSecret};ios={iosAppSecret}", typeof(Crashes), typeof(Analytics));

            // MASTERCLASS - REACTING TO CRASHES
            // IF APP CRASHED IN THE LAST USE
            // se o app teve crash e não foi capturado por try/catch
            bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();
            if (didAppCrash)
            {
                // MASTERCLASS - coleta varias informações de crash
                // informações de crash que não foram capturadas também são exibidas no appcenter
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }

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
