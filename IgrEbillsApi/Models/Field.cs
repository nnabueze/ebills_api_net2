using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models
{
    public class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Required { get; set; }
        public bool Readonly { get; set; }
        public int MaxLength { get; set; }
        public int Order { get; set; }
        public bool RequiredInNextStep { get; set; }
        public bool AmountField { get; set; }
        public IList<Item> Item { get; set; }
    }
}