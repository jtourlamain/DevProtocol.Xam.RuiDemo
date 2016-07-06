using System;
using System.Reactive.Disposables;
using Xamarin.Forms;
using ReactiveUI;

namespace DevProtocol.Xam.RuiDemo.Views
{
	public abstract class ReactiveContentPage<TViewModel>: ContentPage, IViewFor<TViewModel> where TViewModel:class
	{
		
		public ReactiveContentPage()
		{
			ViewModel = Activator.CreateInstance<TViewModel>();
			SetupUserInterface();
			SetupReactiveObservables();
		}

		protected readonly CompositeDisposable SubscriptionDisposables = new CompositeDisposable();

		//public static readonly BindableProperty ViewModelProperty =
		//	BindableProperty.Create<ReactiveContentPage<TViewModel>, TViewModel>(x => x.ViewModel, null, BindingMode.OneWay);

		public static readonly BindableProperty ViewModelProperty =
			BindableProperty.Create(nameof(ViewModel), typeof(TViewModel), typeof(ReactiveContentPage<TViewModel>), null, BindingMode.OneWay);

		#region IViewFor implementation
		public TViewModel ViewModel
		{
			get
			{
				return (TViewModel)GetValue(ViewModelProperty);
			}
			set
			{
				SetValue(ViewModelProperty, value);
			}
		}
		#endregion

		#region IViewFor implementation
		object IViewFor.ViewModel
		{
			get
			{
				return ViewModel;
			}
			set
			{
				ViewModel = (TViewModel)value;
			}
		}
		#endregion

		protected virtual void SetupUserInterface() { }

		protected virtual void SetupReactiveObservables() { }

		protected virtual void SetupReactiveSubscriptions() { }

		protected override void OnAppearing()
		{
			SetupReactiveSubscriptions();

			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			SubscriptionDisposables.Clear();
			base.OnDisappearing();
		}
	}
}

