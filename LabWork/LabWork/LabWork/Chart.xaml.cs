using Microcharts;
using SkiaSharp;
using Microcharts.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;

namespace LabWork
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chart : ContentPage
    {
        List<Entry> entries = new List<Entry>
        {
            new Entry(0)
            {
                Color=SKColor.Parse("#FF1943"),
                Label ="1",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "2",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "3",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "4",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "5",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "6",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "7",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "8",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "9",
                ValueLabel = "0"
            },
            new Entry(0)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "10",
                ValueLabel = "0"
            }
        };

        public Chart()
        {
            InitializeComponent();

            Chart1.Chart = new LineChart() {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18,
            };
        }

        private void getChart(object sender, EventArgs e)
        {
            entries = new List<Entry>();
            IEnumerable<RateInfoTable> list = App.Database.GetItems();

            foreach(var tmp in list)
            {
                if (pickerChart.Items[pickerChart.SelectedIndex] == tmp.CharCode)
                {
                    entries.Add(new Entry((float)tmp.Value)
                    {
                        Color = SKColor.Parse("#FF1943"),
                        Label = tmp.Timestamp,
                        ValueLabel = tmp.Value.ToString()
                    });
                }
            }
            Chart1.Chart = new LineChart()
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Square,
                PointSize = 18,
            };
        }
    }
}