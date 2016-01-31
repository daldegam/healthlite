using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Net.Http;
using HealtyLite.Model;
using Newtonsoft.Json;
using Xamarin;

namespace HealtyLite.Views
{
	public partial class CadastroUsuario : ContentPage
	{
		public CadastroUsuario ()
		{
			InitializeComponent ();
		}

		private async void cadastraUsuario (object e, EventArgs a)
		{

			String erro = String.Empty;

			if (Senha.Text == null || Senha.Text.Length > 4) {
				erro += "Digite no minimo 4 caracteres\n"; 
			} else if (!Senha.Text.Equals (senha1.Text)) {
				erro += "As senhas não coensidem\n"; 

			}
				

			if (Nome.Text == null) {
				erro += "Nome não pode ficar em branco!\n"; 
			}


			if (Email.Text == null) {
				erro += "Email não pode ficar em branco!\n"; 
			}

			if (Telefone.Text == null) {
				erro += "Celular não pode ficar em branco!\n"; 
			}
				

			if (Peso.Text == null) {
				erro += "Peso não pode ficar em branco!\n"; 
			}

			if (Altura.Text == null) {
				erro += "Altura não pode ficar em branco!\n"; 
			}


			if (erro != String.Empty) {
				await DisplayAlert ("Erro", erro, "Fechar");
			} else {
				Dictionary<String, String> campos = new Dictionary<string, string> ();
				campos ["Altura"] = Altura.Text;
				campos ["Peso"] = Peso.Text;
				campos ["Telefone"] = Telefone.Text;
				campos ["Email"] = Email.Text;
				campos ["Nome"] = Nome.Text;
				campos ["Senha"] = Senha.Text;
				campos ["Nascimento"] = "" + Nascimento.Date;
				campos ["Sexo"] = "" + Sexo.SelectedIndex; 

				try {
					var url = Convert.ToString (String.Format (App.url));
					var uri = new Uri (url);
					HttpClient m = new HttpClient ();
					m.DefaultRequestHeaders.Add ("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
					HttpContent content = new FormUrlEncodedContent (campos);
					HttpResponseMessage response = await m.PostAsync (uri, content);
					response.EnsureSuccessStatusCode ();
					var resposta = await response.Content.ReadAsStringAsync ();
					var texto = JsonConvert.DeserializeObject<PessoaMOD> (resposta);
					App.Current.Properties ["login"] = resposta;
					await App.Current.SavePropertiesAsync ();
					await this.Navigation.PopAsync ();
				} catch (Exception ex) {
					Insights.Report (ex);
					await DisplayAlert ("Erro", "Não foi possivel fazer o cadastro\nPor favor tente mais tarde!", "Fechar");
				}

			}

		}


	}
}

