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
    public partial class PageRequestHistoryDescription : ContentPage
    {
        public PageRequestHistoryDescription()
        {
            InitializeComponent();
        }

        private void delete(object sender, EventArgs e)
        {
            var friend = (RateInfoTable)BindingContext;
            App.Database.DeleteItem(friend.Id);
            this.Navigation.PopAsync();
        }
    }
}