using Examen_Septembre_2022.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Examen_Septembre_2022.ViewModel
{
    internal class ProductVM : INotifyPropertyChanged
    {

        private NorthwindContext dc = new NorthwindContext();
        private ObservableCollection<ProductModel> _ProductsList;
        private ObservableCollection<ProductModel> _ProductsPrice;

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
                if (!item.Discontinued)
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
                OnPropertyChanged("ProductsPrice");
            }
        }


        public DelegateCommand UpdateCommand
        {
            get { return _updateCommand = _updateCommand ?? new DelegateCommand(UpdateProduct); }
        }



        private void UpdateProduct()
        {
            Product verif = dc.Products.Where(e => e.ProductId == SelectedProduct.MonProduct.ProductId).SingleOrDefault();
            if (verif == null)
            {
                dc.Products.Add(SelectedProduct.MonProduct);
            }

            dc.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }

        // affiche Pour tous les products
        public ObservableCollection<ProductModel> ProductsPrice
        {
            get
            {             
                return _ProductsPrice = _ProductsPrice ?? load(); ;
            }
        }

        private ObservableCollection<ProductModel> load()
        {
            ObservableCollection<ProductModel> localCollection = new ObservableCollection<ProductModel>();
            var query = from OrderDetail o in dc.OrderDetails.AsEnumerable()
                        orderby o.ProductId
                        group o by o.ProductId into groupedOrders
                        select new ProductModel(new Product
                        {
                            ProductId = groupedOrders.Key,
                        })
                        {
                            TotalPrice = groupedOrders.Sum(o => o.UnitPrice * o.Quantity)
                        };

            foreach (var productModel in query)
            {
                localCollection.Add(productModel);
            }

            return localCollection;
        }


        // Lorsque l'on clique ca nous montre celui du Product

        //public ObservableCollection<ProductModel> ProductsPrice
        //{
        //    get
        //    {
        //        if (SelectedProduct != null)
        //        {
        //            _ProductsPrice = load();
        //        }
        //        return _ProductsPrice;
        //    }
        //}

        //private ObservableCollection<ProductModel> load()
        //{
        //    ObservableCollection<ProductModel> localCollection = new ObservableCollection<ProductModel>();
        //    var query = from OrderDetail o in dc.OrderDetails.AsEnumerable()
        //                where(o.ProductId == SelectedProduct.MonProduct.ProductId)
        //                orderby o.ProductId
        //                group o by o.ProductId into groupedOrders
        //                select new ProductModel(new Product
        //                {
        //                    ProductId = groupedOrders.Key,
        //                })
        //                {
        //                    TotalPrice = groupedOrders.Sum(o => o.UnitPrice * o.Quantity)
        //                };

        //    foreach (var productModel in query)
        //    {
        //        localCollection.Add(productModel);
        //    }

        //    return localCollection;
        //}


    }
}
