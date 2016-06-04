using System;
using System.Collections.Generic;

namespace TiplessCashJar
{
	public class Beacon
	{
		double distance;
		string uuid;
		int major;
		int minor;
		string name;

		public enum Proximity {
			Immediate,
			Near,
			Far,
			VeryFar
		};

		Proximity proximity;

		public Beacon (string name, double distance, string uuid, int major, int minor, Proximity proximity)
		{
			this.name = name;
			this.distance = distance;
			this.uuid = uuid;
			this.major = major;
			this.minor = minor;
			this.proximity = proximity;
		}

		public double Distance {
			get {
				return distance;
			}
		}

		public string UUID {
			get {
				return uuid;
			}
		}

		public int Major {
			get {
				return major;
			}
		}

		public int Minor {
			get {
				return minor;
			}
		}

		public string Name {
			get {
				return name;
			}
		}
			
		public static Predicate<Beacon> Matcher(Beacon thatBeacon) {
			return delegate(Beacon beacon) {
				if (beacon.UUID.CompareTo (thatBeacon.UUID) == 0 && beacon.Minor == thatBeacon.Minor) {
					return true;
				}

				return false;
			};
		}
	}


	public class BeaconsFoundEventArgs : EventArgs
	{
		List<Beacon> beacons;

		public BeaconsFoundEventArgs(List<Beacon> beacons)
		{
			this.beacons = beacons;
		}

		public List<Beacon> Beacons {
			get {
				return beacons;
			}
		}
	}

	public delegate void BeaconsFoundHandler(object sender, BeaconsFoundEventArgs e);

	public interface IBeaconManager
	{
		void StartScanning(List<Beacon> knownBeacons);
		void StopScanning();

		event BeaconsFoundHandler BeaconsFound; 
	}
}

