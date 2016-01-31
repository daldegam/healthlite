using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using HealtyLite.Model;
using Xamarin;
using System.Net;
using System.Text;

namespace HealtyLite.Views
{
	public partial class Home : ContentPage
	{
		public Home ()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent ();
		}



		private async void login(object e,EventArgs a) {

			if (email.Text == null || senha.Text == null) {
				await DisplayAlert ("Erro", "Por favor, digite o email e a senha", "Fechar");
			} else {


				Uri uri = new Uri (String.Format(App.url + "?email={0}&senha={1}", email.Text.Trim (), senha.Text.Trim ()));

					HttpClient m = new HttpClient ();
					m.BaseAddress = uri;
					m.DefaultRequestHeaders.Add ("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

				HttpResponseMessage response = await m.GetAsync ("");


				if (response.StatusCode!=HttpStatusCode.OK) {
					await DisplayAlert ("Erro", "Email ou Senha incorretos!\n\nPor favor tente novamente!", "Sair");
					return;
				}

					response.EnsureSuccessStatusCode ();
					var resposta = await response.Content.ReadAsStringAsync ();

				try {
					

					var texto = JsonConvert.DeserializeObject<PessoaMOD> (resposta);
					App.Current.Properties["login"]= resposta;
					App.Current.SavePropertiesAsync();
					App.master.Detail = new Report();
					App.master.Master = new Report();

				} catch (Exception ex) {
					Insights.Report (ex);

					var confirm = await DisplayAlert ("Erro", "Erro ao conectar no servidor!\n\nVocê gostaria de tentar novamente?", "Sim", "Não");
					if (!confirm)  {
						email.Text = String.Empty;
						senha.Text = String.Empty;
					}

				}




			}

		}
			
		private async void cadastrarUsuario(object e, EventArgs a) {

			await App.master.Detail.Navigation.PushAsync (new CadastroUsuario ());
			App.master.IsPresented = false;

		}


	}
}

