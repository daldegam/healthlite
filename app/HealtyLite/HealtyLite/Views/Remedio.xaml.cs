using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace HealtyLite
{
	public partial class Remedio : ContentPage
	{
		public Remedio ()
		{
			InitializeComponent ();
		}
		async void ClickedCadastrar(object sender, EventArgs e)
		{

			if (remedioNome.Text == null || frequenciaHH.Text  == null || frequenciaMM.Text  == null) {

				await DisplayAlert ("ERRO", "Verifique se preencheu os campos", "Voltar");

			} else {

				var remedio = remedioNome.Text;
				var frequenciaRemedioHH = frequenciaHH.Text;
				var frequenciaRemedioMM = frequenciaMM.Text;

			}
				
		}
	}
}

