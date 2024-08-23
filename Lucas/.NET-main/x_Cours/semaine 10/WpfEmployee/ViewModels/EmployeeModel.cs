using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
using WpfEmployee.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WpfEmployee.ViewModels 
{
    public class EmployeeModel : INotifyPropertyChanged
    {

        // wrapping
        private readonly Employee _monEmployee;

        public EmployeeModel(Employee current)
        {
            this._monEmployee = current;
        }



        /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/

        public Employee MonEmployee
        {
            get { return _monEmployee; }
        }

        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged; // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // On notifie que la propriété a changé
            }
        }

        /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/




        // get et set

        public String LastName
        {
            get { return _monEmployee.LastName; }
            set{_monEmployee.LastName = value;
    /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/
                OnPropertyChanged("FullName");
    /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/

            }

        }

        public String FirstName
        {
            get { return _monEmployee.FirstName; }
            set { _monEmployee.FirstName = value;
    /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/
                OnPropertyChanged("FullName");
    /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/
            }
        }

        public DateTime? BirthDate
        {
            get { return _monEmployee.BirthDate; }
            set {_monEmployee.BirthDate = value;
    /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/
                OnPropertyChanged("DisplayBirthDate");
    /*-----------------------------------------------------semaine 10 : changement----------------------------------------------------------*/

            }
        }

        public DateTime? HireDate
        {
            get { return _monEmployee.HireDate; }
            set {_monEmployee.HireDate = value;}
        }



        public String FullName
        {
            get { return String.Format("{0} {1}", _monEmployee.FirstName, _monEmployee.LastName).Trim(); }
        }

        public String DisplayBirthDate
        {
            get
            {
                if (_monEmployee.BirthDate.HasValue)
                {
                    return _monEmployee.BirthDate.Value.ToShortDateString();
                }

                return "";
            }
        }

        public string TitleOfCourtesy
        {
            get { return _monEmployee.TitleOfCourtesy; }
            set {_monEmployee.TitleOfCourtesy = value;}
        }



    }
}
