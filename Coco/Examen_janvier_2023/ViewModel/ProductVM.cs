using Examen_janvier_2023.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Examen_janvier_2023.ViewModel
{
    internal class ProductVM : INotifyPropertyChanged
    {

        private NorthwindContext dc = new NorthwindContext();
        private ObservableCollection<ProductModel> _ProductsList;
        public ObservableCollection<ProductSaleModel> _ProductSales;


        private ProductModel _selectedProduct;
        private DelegateCommand _updateCommand;


        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }


        public ObservableCollection<ProductModel> ProductsList
        {
            get
            {
                return _ProductsList = _ProductsList ?? loadProducts();
            }
        }
        private ObservableCollection<ProductModel> loadProducts()
        {
            ObservableCollection<ProductModel> localCollection = new ObservableCollection<ProductModel>();
            foreach (var item in dc.Products)
            {
                if(!item.Discontinued)
                {
                    localCollection.Add(new ProductModel(item));
                }

            }

            return localCollection;

        }


        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
            }

        }



        public DelegateCommand UpdateCommand
        {
            get { return _updateCommand = _updateCommand ?? new DelegateCommand(UpdateProduct); }
        }



        private void UpdateProduct()
        {

            if (SelectedProduct != null && SelectedProduct.MonProduct != null)
            {
                Console.WriteLine(SelectedProduct.MonProduct);

                // Récupérez le produit sélectionné
                Product productToUpdate = dc.Products
                    .FirstOrDefault(p => p.ProductId == SelectedProduct.MonProduct.ProductId);

                if (productToUpdate != null)
                {
                    productToUpdate.Discontinued = true;

                    dc.SaveChanges();

                    _ProductsList.Remove(SelectedProduct);

                    MessageBox.Show("Produit retiré du catalogue.");
                }
            }
        }

        public ObservableCollection<ProductSaleModel> ProductSales
        {
            get
            {
                return _ProductSales = _ProductSales ?? LoadProductSales();
            }
        }


        private ObservableCollection<ProductSaleModel> LoadProductSales()
        {
            ObservableCollection<ProductSaleModel> localCollection = new ObservableCollection<ProductSaleModel>();
            if (SelectedProduct != null && SelectedProduct.MonProduct != null)
            {
                var productId = SelectedProduct.MonProduct.ProductId;

                var productSales = dc.OrderDetails
                    .Where(od => od.ProductId == productId)
                    .GroupBy(od => od.Order.ShipCountry)
                    .Select(g => new ProductSaleModel
                    {
                        Country = g.Key,
                        ProductCount = g.Sum(od => od.Quantity)
                    })
                    .OrderByDescending(ps => ps.ProductCount)
                    .ToList();

                localCollection = new ObservableCollection<ProductSaleModel>(productSales);
            }

            return localCollection;
        }



    }
}
