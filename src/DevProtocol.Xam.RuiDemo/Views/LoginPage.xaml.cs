using System;
using System.Reactive.Linq;
using System.Collections.Generic;
using ReactiveUI;
using Xamarin.Forms;
using DevProtocol.Xam.RuiDemo.ViewModels;

namespace DevProtocol.Xam.RuiDemo.Views
{
	public partial class LoginPage : ContentPage, IViewFor<LoginViewModel>
	{
		public LoginPage()
		{
			InitializeComponent();
			ViewModel = new LoginViewModel();
			this.Bind(ViewModel, vm => vm.Email, v => v.Email.Text);
			this.Bind(ViewModel, vm => vm.Password, v => v.Password.Text);
			this.BindCommand(ViewModel, vm => vm.Login, v => v.Login);

			this.WhenAnyValue(x => x.ViewModel.IsLoading)
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(busy =>
				{
					Email.IsEnabled = !busy;
					Password.IsEnabled = !busy;
					Loading.IsVisible = busy;
				});
				
		}

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create(nameof(ViewModel), typeof(LoginViewModel), typeof(LoginPage), null, BindingMode.OneWay);

		public LoginViewModel ViewModel
		{
			get { return (LoginViewModel)GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}

		object IViewFor.ViewModel
		{
			get { return ViewModel; }
			set { ViewModel = (LoginViewModel)value; }
		}
	}
}

