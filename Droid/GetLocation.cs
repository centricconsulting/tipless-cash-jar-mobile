using System;
using Android.Content;
using Android.Locations;
using Android.OS;
using TiplessCashJar.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(GetLocation))]
namespace TiplessCashJar.Droid
{
    class LocationEventArgs: EventArgs, ILocationEventArgs
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
    public class GetLocation: Java.Lang.Object, ILocation, ILocationListener
    {
        LocationManager lm;
        public void OnProviderDisabled(string provider) { }
        public void OnProviderEnabled(string provider) { }
        public void OnStatusChanged(string provider, Availability status, Bundle extra) { }

        //--- fired whenever there is a change in location---
        public void OnLocationChanged(Location location)
        {
            if(location != null)
            {
                LocationEventArgs args = new LocationEventArgs();
                args.lat = location.Latitude;
                args.lng = location.Longitude;
                locationObtained(this, args);
            };
        }

        //--- an EvenHandler delegate that is called when a location is obtained ---
        public event EventHandler<ILocationEventArgs> locationObtained;

        //--- custom event accessor that is invoked when client subscribes to the event ---
        event EventHandler<ILocationEventArgs> ILocation.LocationObtained
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

        //--- method to call to start getting location---
        public void ObtainLocation()
        {
            lm = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);

            lm.RequestLocationUpdates(
                LocationManager.NetworkProvider,
                0, //---time in ms---
                0, //---distance in meters---
                this);
        }

        //---stop the location update when the object is set to null---
        ~GetLocation()
        {
            lm.RemoveUpdates(this);
        }
    }
}