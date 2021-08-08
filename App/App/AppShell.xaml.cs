
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Screens
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppShell : Shell
	{
		private static AppShell Instance;

		public AppShell()
		{
			InitializeComponent();

			Instance = this;
		}
	}
}
