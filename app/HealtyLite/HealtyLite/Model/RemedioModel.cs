using System;

namespace HealtyLite
{
	public class RemedioModel
	{
		public string Nome {
			get;
			set;
		}

		public int IntervaloDose {
			get;
			set;
		}

		public DateTime DataUltimaDoseMinistrada {
			get;
			set;
		}

		public RemedioModel ()
		{
		}
	}
}

