﻿using System;
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
    public partial class WorkoutDetailPage : ContentPage
    {
        public WorkoutDetailPage()
        {
            InitializeComponent();
            BindingContext = new WorkoutDetailViewModel(stackLayoutExercise, stackButtonBodyParts);
        }
    }
}