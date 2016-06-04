using System;
using CoreLocation;
using TiplessCashJar.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation))]
namespace TiplessCashJar.iOS
{
    //---Event arguments containing lat and lng---
    public class LocationEventArgs: EventArgs, ILocationEventArgs
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class GetLocation: ILocation
    {
        CLLocationManager lm;
        //---and EventHandler delegate tat is called when a location is obtained---
        public event EventHandler<ILocationEventArgs> locationObtained;

        //---custom event accessor when client subscribes to the event---
        event EventHandler<ILocationEventArgs>
            ILocation.LocationObtained
        {
            add
            {
                locationObtained += value;
            }
            remove
            {
                locationObtained -= value;
            }
        }

        //---method to call to start getting location---
        public void ObtainLocation()
        {
            lm = new CLLocationManager();
            lm.DesiredAccuracy = CLLocation.AccuracyBest;
            lm.DistanceFilter = CLLocationDistance.FilterNone;
            //---fired whenever there is a change in location ---
            lm.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
            {
                var locations = e.Locations;
                var strLocations = locations[locations.Length - 1].Coordinate.Latitude.ToString();
                strLocations = strLocations + "," + locations[locations.Length - 1].Coordinate.Latitude.ToString();

                LocationEventArgs args = new LocationEventArgs();
                args.lat = locations[locations.Length - 1].Coordinate.Latitude;
                args.lng = locations[locations.Length - 1].Coordinate.Longitude;
                locationObtained(this, args);
            };
            lm.RequestWhenInUseAuthorization();
        }

        //---stop the location update when the object is set to null---
        ~GetLocation()
        {
            lm.StopUpdatingLocation();
        }
    }
}
