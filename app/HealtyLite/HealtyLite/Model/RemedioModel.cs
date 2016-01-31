using System;


namespace HealtyLite.Model
{
	public class RemedioModel
	{
		
		public int Id {
			get;
			set;
		}

		
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

