using System;
using Xamarin.Forms;
using HealtyLite.Model;
using HealtyLite.Views;
using Newtonsoft.Json;

namespace HealtyLite
{
	public class App : Application
	{
		public static PessoaMOD sessao() {
			return JsonConvert.DeserializeObject<PessoaMOD> (App.Current.Properties ["login"].ToString ());
		}

		public static MasterDetailPage	master;

		public static readonly String  url = "http://192.168.10.122:8099/api/pessoa";

		public App ()
		{

			master = new MasterDetailPage ();

			master.Title = "HealthLite";

			master.Master = new Home ();

			master.Detail = new ContentPage ();

			if (!App.Current.Properties.ContainsKey ("login")) {

				//master.MasterBehavior = MasterBehavior.Popover;
				//master.IsGestureEnabled = false;
				master.Detail = new NavigationPage (new Home ());
			} else {
				//master.MasterBehavior = MasterBehavior.Default;
				//master.IsGestureEnabled = true;
				//home de login
				master.Master = new Home ();

				master.Detail = new NavigationPage (new Report());
			}

			MainPage = master; 

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

