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
    public partial class PageShell : Shell
    {
        public PageShell()
        {
            InitializeComponent();
        }
    }
}