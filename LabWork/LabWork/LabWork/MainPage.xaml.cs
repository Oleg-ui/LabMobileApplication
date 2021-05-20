using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LabWork
{
    public partial class MainPage : ContentPage
    {
        RateViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();

            viewModel = new RateViewModel();
            this.BindingContext = viewModel;
        }

        private void getValute(object sender, EventArgs e)
        {
            viewModel.getValute(picker.Items[picker.SelectedIndex]);
        }
    }
}
