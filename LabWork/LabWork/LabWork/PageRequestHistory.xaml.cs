using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabWork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRequestHistory : ContentPage
    {
        public PageRequestHistory()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            RateInfoList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            RateInfoTable selectedFriend = (RateInfoTable)e.SelectedItem;
            PageRequestHistoryDescription friendPage = new PageRequestHistoryDescription();
            friendPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(friendPage);
        }
    }
}