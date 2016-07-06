using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ReactiveUI;

namespace DevProtocol.Xam.RuiDemo.ViewModels
{
	public class LoginViewModel: ReactiveObject
	{
		public LoginViewModel()
		{
			var canLogin = this.WhenAnyValue(x => x.Email,
										x => x.Password,
										(em, pa) =>
										{
											return !String.IsNullOrWhiteSpace(em) &&
					                                      Regex.IsMatch(em,
					  @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
					  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
					  RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) &&
					                                      !String.IsNullOrWhiteSpace(pa);
										});
			Login = ReactiveCommand.CreateAsyncTask(canLogin, async (arg) =>
			{
				await Task.Delay(4000).ConfigureAwait(false);
			});

			Login.IsExecuting.ToProperty(this, x => x.IsLoading, out _isLoading);
		}

		public ReactiveCommand<System.Reactive.Unit> Login { get; protected set; }

		readonly ObservableAsPropertyHelper<bool> _isLoading;
		public bool IsLoading
		{
			get { return _isLoading.Value; }
		}

		string _email;
		public string Email
		{
			get { return _email; }
			set { this.RaiseAndSetIfChanged(ref _email, value); }
		}

		string _password;
		public string Password
		{
			get { return _password; }
			set { this.RaiseAndSetIfChanged(ref _password, value); }
		}
	}

}

