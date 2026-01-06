using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfLibrary.Domain.Entities
{
    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string second_name { get; set; } = string.Empty;
        public string first_lastname { get; set; }
        public string second_lastname { get; set; } = string.Empty;
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime register_date { get; set; }

        // 1 Usuario -> Muchos Préstamos
        public List<Loan> Loans { get; set; } = new List<Loan>();

    }
}
