
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App.Screens;

namespace App
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new Screen_Main());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
