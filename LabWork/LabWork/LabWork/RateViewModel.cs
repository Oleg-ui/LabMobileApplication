using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace LabWork
{
    public class RateViewModel : INotifyPropertyChanged
    {
        private decimal value;
        private decimal previous;
        private DateTime date;
        private string charcode;
        private string name;
        private int nominal;

        public decimal Value
        {
            get { return value; }
            private set
            {
                this.value = value;
                OnPropertyChanged("Value");
            }
        }
        public decimal Previous
        {
            get { return previous; }
            private set
            {
                this.previous = value;
                OnPropertyChanged("Previous");
            }
        }

        public DateTime Date
        {
            get { return date; }
            private set
            {
                this.date = value;
                OnPropertyChanged("Date");
            }
        }

        public string CharCode
        {
            get { return charcode; }
            private set
            {
                this.charcode = value;
                OnPropertyChanged("CharCode");
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Nominal
        {
            get { return nominal; }
            private set
            {
                this.nominal = value;
                OnPropertyChanged("Nominal");
            }
        }

        public RateViewModel()
        {

        }

        public async void getValute(string name)
        {
            string url = "https://www.cbr-xml-daily.ru/daily_json.js";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"$.Valute." + name);

                var rateInfo = JsonConvert.DeserializeObject<RateInfo>(str.ToString());

                this.Value = rateInfo.Value;
                this.Previous = rateInfo.Previous;
                this.CharCode = rateInfo.CharCode;
                this.Name = rateInfo.Name;
                this.Nominal = rateInfo.Nominal;

                str = o.SelectToken(@"$");
                rateInfo = JsonConvert.DeserializeObject<RateInfo>(str.ToString());

                this.Date = rateInfo.Timestamp;

                RateInfoTable objectRateInfo = new RateInfoTable();
                objectRateInfo.Timestamp = DateTime.Now.ToString();
                objectRateInfo.CharCode = this.charcode;
                objectRateInfo.Name = this.name;
                objectRateInfo.Nominal = this.nominal;
                objectRateInfo.Value = this.value;
                objectRateInfo.Previous = this.previous;

                App.Database.SaveItem(objectRateInfo);
            }
            catch (Exception ex)
            { }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
