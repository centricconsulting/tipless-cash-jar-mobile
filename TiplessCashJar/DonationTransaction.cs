using System;
using System.Globalization;

namespace TiplessCashJar
{
	public class DonationTransaction
	{
		private string name;
		private string date;
		private int amount;

		public string Name {
			get {
				return name;
			}
		}

		public string Date {
			get {
				return date;
			}
		}

		public int Amount {
			get {
				return amount;
			}
		}

		public DonationTransaction (string name, string date, int amount)
		{
			this.name = name;
			this.date = date;
			this.amount = amount;
		}
	}
}

