using System;
using System.Collections.Generic;

namespace CurrencyList.Server.Models
{
    public partial class Currencies
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public string CurrencyCode { get; set; }
    }
}
