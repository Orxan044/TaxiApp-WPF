using System.Configuration;
using System.Windows.Input;

namespace UserPanel.ViewModels;

public class UserMapViewModel : ViewModel
{
    currentdeparture = new Departure();
    Distance = 0;
					taxies.Clear();
					Route = new ObservableCollection<UIElement>();

					string URL = "http://dev.virtualearth.net/REST/V1/Routes/Driving?wp.0=" +
                   $"{From}" + ",MN&wp.1=" + $"{To}" +
                   ",MN&optmz=distance&routeAttributes=routePath&key=" + ConfigurationManager.AppSettings["apiKey"];

    var geocodeRequest = new Uri(URL);
    var r = await GetResponse(geocodeRequest);

    FromLatitude = ((Route)(r.ResourceSets[0].Resources[0])).RoutePath.Line.Coordinates[0][0];
					FromLongitude = ((Route)(r.ResourceSets[0].Resources[0])).RoutePath.Line.Coordinates[0][1];


					float currentdeparture_price = (float)(((Route)(r.ResourceSets[0].Resources[0])).TravelDistance * Admin_Page_SetPrice_ViewModel.XValue);
    currentdeparture.Cost = currentdeparture_price.ToString() + " AZN";
					Price = currentdeparture.Cost;
					currentdeparture.Distance = (float) ((Route)(r.ResourceSets[0].Resources[0])).TravelDistance;



					var location = new Microsoft.Maps.MapControl.WPF.Location(FromLatitude, FromLongitude);
}


