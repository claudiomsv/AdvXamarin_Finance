using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Finance.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //IOS IMPORTANT
            //IPHONE X / Xs / Xs Max
            //Inibe que o conteudo invada a barra inferior (que controla navegação nos dispositivos acima)
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }
    }
}
