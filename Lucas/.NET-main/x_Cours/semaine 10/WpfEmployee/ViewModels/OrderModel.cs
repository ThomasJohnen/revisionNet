using System;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class OrderModel
    {

        private readonly Order _monOrder;
        private readonly int _total;
        private decimal total;

        public OrderModel(Order current, int total)
        {
            this._monOrder = current;
            this._total = total;
        }

        public String OrderID
        {
            get{return _monOrder.OrderId.ToString();}
        }

        public int Total
        {
            get { return _total; }
        }


    }
}
