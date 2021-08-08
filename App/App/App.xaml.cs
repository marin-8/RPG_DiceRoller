
using Xamarin.Forms;

using App.Logic;
using App.Screens;

namespace App
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
			Logic_LoadSave.Load();
		}

		protected override void OnSleep()
		{
			Logic_LoadSave.Save();
		}

		protected override void OnResume()
		{
		}
	}
}
