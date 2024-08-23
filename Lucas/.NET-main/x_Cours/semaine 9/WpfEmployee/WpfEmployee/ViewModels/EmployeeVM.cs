using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    class EmployeeVM
    {

        private NorthwindContext dc = new NorthwindContext();
        private List<EmployeeModel> _EmployeesList;
        private List<string> _listTitle;

        //Code de mainWindow

        //<DataGrid Name = "dgCustomers" Margin="6" Grid.Row="1" AutoGenerateColumns="False" ItemsSource="{Binding EmployeesList}" IsReadOnly="True">
        //    <DataGrid.Columns>
        //        <!--<DataGridTextColumn Binding = "{Binding LastName}" Header="Name" Width="*" />-->
        //        <DataGridTextColumn Binding = "{Binding FullName}" Header="Full Name" Width="*" />
        //        <DataGridTextColumn Binding = "{Binding DisplayBirthDate}" Header="Birth Date" Width="*" />
        //    </DataGrid.Columns>
        //</DataGrid>


        // on peux voir dans le code de mainWindow
        //ItemsSource="{Binding EmployeesList}"
        public List<EmployeeModel> EmployeesList
        {
            get
            {
                return _EmployeesList = _EmployeesList ?? loadEmployee();
            }
        }
        private List<EmployeeModel> loadEmployee()
        {
            List<EmployeeModel> localCollection = new List<EmployeeModel>();
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




    }
}
