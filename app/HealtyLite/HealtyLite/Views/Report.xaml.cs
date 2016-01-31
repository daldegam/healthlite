using System;
using System.Collections.Generic;
using Xamarin.Forms;
using HealtyLite.Model;

namespace HealtyLite.Views
{
	public partial class Report : ContentPage
	{
		public Report ()
		{
			InitializeComponent ();

			DispararEventosControleMedicamento ();

			BindingContext = new ReportModel ().MontarRelatorio ();
		}

		public void DispararEventosControleMedicamento()
		{
			
		}
	}
}

