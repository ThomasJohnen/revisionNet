﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_janvier_2023.ViewModel
{
    internal class ProductSaleModel
    {
        public String _country;
        public int _productCount;

        public string Country
        {
            get { return this._country; }
            set { this._country = value; }
        }
        public int ProductCount
        {
            get { return this._productCount; }
            set { this._productCount = value; }
        }

    }
}
