using System;
using System.Collections.Generic;

namespace Examen_Septembre_2022.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
