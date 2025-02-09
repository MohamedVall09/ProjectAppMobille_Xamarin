using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Sport.ViewModels;

namespace Sport.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainingPage : ContentPage
    {

        UserRepository _userRepository = new UserRepository();

        TrainingViewModel _trainingViewModel;
        public TrainingPage()
        {
            InitializeComponent();
            _trainingViewModel = new TrainingViewModel(StackDayTraining);
            BindingContext = _trainingViewModel = new TrainingViewModel(StackDayTraining);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _trainingViewModel.OnAppearing();
        }
        private async void Logout_Click(object sender, EventArgs e)
        {
            _userRepository.SignOut();
            Application.Current.MainPage = new LoginPage();
        }
    }
}