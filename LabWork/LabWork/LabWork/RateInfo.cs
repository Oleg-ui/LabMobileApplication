using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LabWork
{
    public class RateInfo
    {
        public DateTime Timestamp { get; set; }
        public string CharCode { get; set; }
        public string Name { get; set; }
        public int Nominal { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
    }
}
