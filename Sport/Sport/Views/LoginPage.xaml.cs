using Xamarin.Forms;
using Xamarin.Essentials;
using System;
using System.Windows.Input;
using Sport.Views;
using Sport;

namespace Sport.Views
{
    public partial class LoginPage : ContentPage
    {
        UserRepository _userRepository = new UserRepository();
        public ICommand TapCommand => new Command(async () => await Navigation.PushModalAsync(new RegisterUser()));

        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false); // Disable back button
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = Temail.Text;
                string password = Tpass.Text;
                if (String.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Warning", "Enter your email", "Ok");
                    return;
                }
                if (String.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Warning", "Enter your password", "Ok");
                    return;
                }
                string token = await _userRepository.SignIn(email, password);
                if (!string.IsNullOrEmpty(token))
                {
                    Preferences.Set("token", token);
                    Preferences.Set("userEmail", email);
                    Application.Current.MainPage = new AppShell();

                }
                else
                {
                    await DisplayAlert("Sign In", "Sign in failed", "ok");
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    await DisplayAlert("Unauthorized", "Email not found", "ok");
                }
                else if (exception.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("Unauthorized", "Password incorrect", "ok");
                }
                else
                {
                    await DisplayAlert("Error", exception.Message, "ok");
                }
            }
        }
        private async void RegisterTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterUser());
        }


        protected override bool OnBackButtonPressed()
        {
            // Prevent navigating back when pressing hardware back button
            return true;
        }
    }
}
