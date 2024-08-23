using Examen_Septembre_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Septembre_2022.ViewModel
{
    internal class ProductModel
    {

        private readonly Product _monProduct;
        public decimal _totalPrice;

        public ProductModel(Product current)
        {
            this._monProduct = current;
        }


        public Product MonProduct
        {
            get { return _monProduct; }
        }


        public int ProductId
        {
            get { return this._monProduct.ProductId; }
            set { _monProduct.ProductId = value; }
        }

        public string ProductName
        {
            get { return this._monProduct.ProductName; }
            set { this._monProduct.ProductName = value; }
        }

        public string? Quantity
        {
            get { return this._monProduct.QuantityPerUnit; }
            set { _monProduct.QuantityPerUnit = value; }
        }

        public string? Fournisseur
        {
            get { return this._monProduct.Supplier?.ContactName; }
            set { this._monProduct.Supplier.ContactName = value; }
        }

        public decimal TotalPrice
        {
            get { return this._totalPrice; }
            set { this._totalPrice=value; }
        }


    }
}
