using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LabWork
{
    [Table("Currencies")]
    public class RateInfoTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Timestamp { get; set; }
        public string CharCode { get; set; }
        public string Name { get; set; }
        public int Nominal { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
    }
}
