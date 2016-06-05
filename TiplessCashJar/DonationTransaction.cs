using System;
using System.Globalization;

namespace TiplessCashJar
{
	public class DonationTransaction
	{
		private int amount;
		private string txDate;
		private string id;

		public string Id {
			get {
				return id;
			}
		}

		public string TxDate {
			get {
				return txDate;
			}
		}

		public int Amount {
			get {
				return amount;
			}
		}

		public DonationTransaction (int amount, string txDate, string id)
		{
			this.id = id;
			this.txDate = txDate;
			this.amount = amount;
		}

		public override string ToString()
		{
			return TxDate;
		}
	}
}

