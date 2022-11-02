using System;
using System.Collections.Generic;
using System.Text;

namespace Dluznik.Core
{
    public class Dluznik
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return Name + ";" + Amount.ToString();
        }

    }
}
