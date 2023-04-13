using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyPRAD.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyPRAD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaSitios : ContentPage
    {
        public ListaSitios()
        {
            InitializeComponent();
        }

        private async void listasitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Models.Sites sitio = (Models.Sites)e.CurrentSelection.FirstOrDefault();

                var mappage = new Views.PageMaps();
                mappage.BindingContext = sitio;
                await Navigation.PushAsync(mappage);
            }
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listasitios.ItemsSource = await DateBase.ObtenerListaSitios();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageUpdSites());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageDelSites());
        }
    }
}