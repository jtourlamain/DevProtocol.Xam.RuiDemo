using Xamarin.Forms;
using DevProtocol.Xam.RuiDemo.Views;

namespace DevProtocol.Xam.RuiDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new DevProtocol.Xam.RuiDemo.Views.LoginPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

