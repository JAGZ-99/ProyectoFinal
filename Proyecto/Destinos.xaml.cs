using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Destinos : ContentPage
    {
        public Destinos()
        {
            InitializeComponent();
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.edestinos.com/vuelos-baratos"));
        }
    }
}