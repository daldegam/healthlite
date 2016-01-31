using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HealtyLite
{
	public partial class Informacoes : ContentPage
	{
		public Informacoes ()
		{
			InitializeComponent ();

			BindingContext = new TelaVM ();
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

		private bool _sAlergia;

		public bool Alergia {
			get { 
				return _sAlergia;
			}
			set { 
				if (_sAlergia != value) {
					_sAlergia = value;
					OnProp ();
				}
			}
		}

		private bool _sInto;

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

