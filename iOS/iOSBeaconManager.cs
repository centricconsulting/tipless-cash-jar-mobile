using System;
using System.Collections.Generic;
using CoreLocation;
using Foundation;
using UIKit;

namespace TiplessCashJar.iOS
{
	public class iOSBeaconManager : IBeaconManager
	{
		private CLLocationManager locationMgr = new CLLocationManager ();
		private List<CLBeaconRegion> regions = new List<CLBeaconRegion> ();
		private List<Beacon> beacons = new List<Beacon>();

		public iOSBeaconManager ()
		{
			locationMgr.RequestAlwaysAuthorization ();

			locationMgr.DidRangeBeacons += LocationMgr_DidRangeBeacons;
			locationMgr.DidStartMonitoringForRegion += LocationMgr_DidStartMonitoringForRegion;;
			locationMgr.RegionEntered += LocationMgr_RegionEntered;
			locationMgr.RegionLeft += LocationMgr_RegionLeft;
		}
			
		public void StartScanning(List<Beacon> knownBeacons) {
			if (ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.SIMULATOR)
				return;
			
			if (knownBeacons != null && knownBeacons.Count > 0) {
				foreach (var beacon in knownBeacons) {
					CLBeaconRegion region = new CLBeaconRegion (new NSUuid (beacon.UUID), beacon.Name);

					region.NotifyOnEntry = true;
					region.NotifyOnExit = true;
					region.NotifyEntryStateOnDisplay = true;

					regions.Add (region);

					locationMgr.StartMonitoring (region);
					locationMgr.StartRangingBeacons (region);
				}
			}
		}

		public void StopScanning() {

			foreach (var region in regions) {
				locationMgr.StopRangingBeacons (region);
				locationMgr.StopMonitoring (region);
			}

			regions.Clear ();
		}

		public event BeaconsFoundHandler BeaconsFound;

		public List<Beacon> Beacons {
			get;
			set;
		}

		#region LocationMgr delegates

		void LocationMgr_DidRangeBeacons (object sender, CLRegionBeaconsRangedEventArgs e) {
			if (e.Beacons.Length > 0) {
				beacons.Clear();
				foreach (var clBeacon in e.Beacons) {
					TiplessCashJar.Beacon.Proximity prox = Beacon.Proximity.VeryFar;

					switch (clBeacon.Proximity) {
					case CLProximity.Immediate:
						prox = Beacon.Proximity.Immediate;
						break;
					case CLProximity.Near:
						prox = Beacon.Proximity.Near;
						break;
					case CLProximity.Far:
						prox = Beacon.Proximity.Far;
						break;
					case CLProximity.Unknown:
						prox = Beacon.Proximity.VeryFar;
						break;
					}

					Beacon beacon = new Beacon("", clBeacon.Accuracy, clBeacon.ProximityUuid.AsString(), clBeacon.Major.Int32Value, clBeacon.Minor.Int32Value, prox);
					beacons.Add(beacon);
				}

				BeaconsFound(this, new BeaconsFoundEventArgs(beacons));
			}
		}

		void LocationMgr_RegionEntered (object sender, CLRegionEventArgs e)
		{
			locationMgr.StartRangingBeacons ((CLBeaconRegion)e.Region);
		}

		void LocationMgr_RegionLeft (object sender, CLRegionEventArgs e)
		{
			locationMgr.StopRangingBeacons ((CLBeaconRegion)e.Region);
		}

		void LocationMgr_DidStartMonitoringForRegion (object sender, CLRegionEventArgs e)
		{
			locationMgr.StartRangingBeacons ((CLBeaconRegion)e.Region);
		}

		#endregion
	}
}

