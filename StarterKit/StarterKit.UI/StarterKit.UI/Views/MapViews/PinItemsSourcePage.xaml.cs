using StarterKit.ViewModels.MapViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace StarterKit.UI.Views.MapViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PinItemsSourcePage : ContentPage
	{
		public PinItemsSourcePage ()
		{
			InitializeComponent ();
            
            BindingContext = new PinItemsSourceViewModel();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(39.8283459, -98.5794797), Distance.FromMiles(1500)));
        }

        private void Map_MapClicked(object sender, MapClickedEventArgs e)
        {
            var geolocaiton = e.Point.Latitude.ToString()+" , " + e.Point.Longitude.ToString();
            DisplayAlert("", geolocaiton, "cancel");
        }

        private void Map_PinClicked(object sender, Xamarin.Forms.GoogleMaps.PinClickedEventArgs e)
        {
            if (e.Pin == null) return;
            
            DisplayAlert("", e.Pin?.Address, "cancel");
        }
    }
}