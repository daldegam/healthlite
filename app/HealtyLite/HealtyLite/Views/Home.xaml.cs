using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HealtyLite
{
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
		}


		private async void cadastrarUsuario(object e, EventArgs a) {
			if (email.Text.Equals ("") || senha.Text.Equals ("")) {
				await DisplayAlert ("Erro", "Por favor, digite o email e a senha", "Fechar");
			} 
		
		}


	}
}

