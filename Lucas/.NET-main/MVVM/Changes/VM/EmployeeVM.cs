using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using WpfApplication1.ViewModels;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class EmployeeVM : INotifyPropertyChanged
    {
        
        private NorthwindContext dc = new NorthwindContext();

    /*-----------------------------------------------------Pour changement----------------------------------------------------------*/

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }


        //private List<EmployeeModel> _EmployeesList;
        private ObservableCollection<EmployeeModel> _EmployeesList;
        private EmployeeModel _selectedEmployee;
        private DelegateCommand _addCommand;
        private DelegateCommand _saveCommand;

    /*-----------------------------------------------------Pour changement----------------------------------------------------------*/


        private List<string> _listTitle;

        private ObservableCollection<OrderModel> _orders;

        public ObservableCollection<EmployeeModel> EmployeesList
        {
            get
            {
                return _EmployeesList = _EmployeesList ?? loadEmployee();
            }
        }
        private ObservableCollection<EmployeeModel> loadEmployee()
        {
            ObservableCollection<EmployeeModel> localCollection = new ObservableCollection<EmployeeModel>();
            foreach (var item in dc.Employees)
            {
                localCollection.Add(new EmployeeModel(item));

            }

            return localCollection;

        }


        public List<string> ListTitle
        {
            get
            {
                return _listTitle = _listTitle ?? loadTitleOfCourtoise();
            }
        }


        private List<string> loadTitleOfCourtoise()
        {
            return dc.Employees.Select(e => e.TitleOfCourtesy).Distinct().ToList();
        }


        public ObservableCollection<OrderModel> OrdersList
        {
            get { return _orders = _orders ?? loadOrders(); }
        }


        private ObservableCollection<OrderModel> loadOrders()
        {
            ObservableCollection<OrderModel> orders = new ObservableCollection<OrderModel>();

            var query = from Order o in dc.Orders
                        where(o.EmployeeId == SelectedEmployee.MonEmployee.EmployeeId)
                        select o;

            var i = 0;
            foreach (var order in query)
            {
                var total = (from OrderDetail od in dc.OrderDetails
                            where(od.OrderId == order.OrderId)
                            select od.UnitPrice).Sum();


                orders.Add(new OrderModel(order, total));
                i++;
                if (i == 3) break;
            }

            return orders;
        }


    /*-----------------------------------------------------Pour changement----------------------------------------------------------*/

        public EmployeeModel SelectedEmployee
        {
            get { return _selectedEmployee; }
            set { _selectedEmployee = value; 
                OnPropertyChanged("OrdersList"); 
            }

        }


        public DelegateCommand SaveCommand
        {
            get { return _saveCommand = _saveCommand ?? new DelegateCommand(SaveEmployee); }
        }

        private void SaveEmployee()
        {
            Employee verif = dc.Employees.Where(e => e.EmployeeId == SelectedEmployee.MonEmployee.EmployeeId).SingleOrDefault();
            if (verif == null)
            {
                dc.Employees.Add(SelectedEmployee.MonEmployee);
            }

            dc.SaveChanges();
            MessageBox.Show("Enregistrement en base de données fait");
        }



        public DelegateCommand AddCommand
        {
            get
            {
                return _addCommand = _addCommand ?? new DelegateCommand(AddEmployee);
            }

        }

        private void AddEmployee()
        {
            Employee EGlobal = new Employee();
            EmployeeModel EModel = new EmployeeModel(EGlobal);
            EmployeesList.Add(EModel);
            SelectedEmployee = EModel;
        }

    /*-----------------------------------------------------Pour changement----------------------------------------------------------*/


    }
}
