using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HealtyLite
{
	public partial class Report : ContentPage
	{
		public Report ()
		{
			InitializeComponent ();
			BindingContext = new ReportModel ().MontarRelatorio ();
		}
	}
}

