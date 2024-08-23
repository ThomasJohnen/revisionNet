using System;
using System.Collections.Generic;
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
    class EmployeeModel
    {

        // wrapping
        private readonly Employee _monEmployee;

        public EmployeeModel(Employee current)
        {
            this._monEmployee = current;
        }


        // get et set


        //Code de mainWindow
        //<StackPanel Grid.Column="1">
        //     <TextBox Height = "27" Margin= "6,6,6,5" Text= "{Binding LastName, UpdateSourceTrigger=PropertyChanged}" />
        //     < TextBox Height= "27" Margin= "6,6,6,5" Text= "{Binding FirstName, UpdateSourceTrigger=PropertyChanged}" />
        //     <ComboBox Name = "cbTitle" Height="27" Margin="6,6,6,5" 
        //               ItemsSource="{Binding DataContext.ListTitle, 
        //          RelativeSource={RelativeSource FindAncestor,
        //          AncestorType = { x:Type Window }}}"
        //              SelectedItem = "{Binding TitleOfCourtesy}" />
        //      < DatePicker Height = "27" Margin = "6,6,6,5" SelectedDate = "{Binding BirthDate}" />
        //      < DatePicker Height = "27" Margin = "6,6,6,5" SelectedDate = "{Binding HireDate}" />
        //</ StackPanel >


        // on peux voir
        // <TextBox Height = "27" Margin= "6,6,6,5" Text= "{Binding LastName, UpdateSourceTrigger=PropertyChanged}" />
        // < TextBox Height = "27" Margin= "6,6,6,5" Text= "{Binding FirstName, UpdateSourceTrigger=PropertyChanged}" />
        // < DatePicker Height = "27" Margin = "6,6,6,5" SelectedDate = "{Binding BirthDate}" />
        // < DatePicker Height = "27" Margin = "6,6,6,5" SelectedDate = "{Binding HireDate}" />

        public String LastName
        {
            get { return _monEmployee.LastName; }
            set{_monEmployee.LastName = value;}
        }

        public String FirstName
        {
            get { return _monEmployee.FirstName; }
            set { _monEmployee.FirstName = value;}
        }

        public DateTime? BirthDate
        {
            get { return _monEmployee.BirthDate; }
            set {_monEmployee.BirthDate = value;}
        }

        public DateTime? HireDate
        {
            get { return _monEmployee.HireDate; }
            set {_monEmployee.HireDate = value;}
        }



        //Code de mainWindow

        //<DataGrid Name = "dgCustomers" Margin="6" Grid.Row="1" AutoGenerateColumns="False" ItemsSource="{Binding EmployeesList}" IsReadOnly="True">
        //    <DataGrid.Columns>
        //        <!--<DataGridTextColumn Binding = "{Binding LastName}" Header="Name" Width="*" />-->
        //        <DataGridTextColumn Binding = "{Binding FullName}" Header="Full Name" Width="*" />
        //        <DataGridTextColumn Binding = "{Binding DisplayBirthDate}" Header="Birth Date" Width="*" />
        //    </DataGrid.Columns>
        //</DataGrid>


        // on peux voir dans le code de mainWindow
        //<DataGridTextColumn Binding = "{Binding FullName}" Header="Full Name" Width="*" />
        public String FullName
        {
            get { return String.Format("{0} {1}", _monEmployee.FirstName, _monEmployee.LastName).Trim(); }
        }

        // on peux voir dans le code de mainWindow
        //<DataGridTextColumn Binding = "{Binding DisplayBirthDate}" Header="Birth Date" Width="*" />
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
