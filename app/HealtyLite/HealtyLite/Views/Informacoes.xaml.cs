using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HealtyLite.Views
{
	public partial class Informacoes : ContentPage
	{
		public Informacoes ()
		{
			InitializeComponent ();

			BindingContext = new TelaVM ();
		}
		async void ClickedCadastrar (object sender, EventArgs e)
		{

			if (remedioNome.Text == null || frequenciaHH.Text == null || frequenciaMM.Text == null || intolerânciaNome.Text == null || alergiaNome.Text == null) {

				await DisplayAlert ("Erro", "Verifique se preencheu todos os campos", "Voltar");

			} else {

				var remedio = remedioNome.Text;
				var frequenciaRemedioHH = frequenciaHH.Text;
				var frequenciaRemedioMM = frequenciaMM.Text;
				var alergia = alergiaNome.Text;
				var intolerancia = intolerânciaNome.Text;
			}

		}
	}

	class TelaVM : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		void OnProp ([CallerMemberName]string member = null)
		{
			var handler = PropertyChanged;
			if (handler != null) {
				handler (this, new PropertyChangedEventArgs (member));
			}
		}

		#endregion

		private bool _sAlergia, _sInto;

		public bool Alergia {
			get { 
				return _sAlergia;
			}
			set { 
				if (_sAlergia != value) {
					_sAlergia = value;
					OnProp ();
					OnProp ("AlergiaFocus");
				}
			}
		}
		public bool AlergiaFocus {
			get{ return _sAlergia; }
			set { 
				if (_sAlergia != value) {
					_sAlergia = value;
					OnProp ();
				}
			}
		}
		public bool Into {
			get { 
				return _sInto;
			}
			set { 
				if (_sInto != value) {
					_sInto = value;
					OnProp ();
				}
			}
		}
		
	}

}

