using DesktopRussionsRoads.Classes;
using DesktopRussionsRoads.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesktopRussionsRoads
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public void ForMainDepartments(int currentDepartment)
		{
			switch (currentDepartment)
			{
				case 1:
					LoadEmployees(2);
					LoadEmployees(3);
					LoadEmployees(4);
					LoadEmployees(5);
					LoadEmployees(6);
					LoadEmployees(7);
					LoadEmployees(10);
					LoadEmployees(11);

					break;
				case 7:
					LoadEmployees(8);
					LoadEmployees(9);
					break;
				case 12:
					LoadEmployees(13);
					LoadEmployees(14);
					LoadEmployees(15);
					LoadEmployees(16);
					break;
				case 18:
					LoadEmployees(19);
					LoadEmployees(20);
					LoadEmployees(23);
					break;
				case 20:
					LoadEmployees(21);
					LoadEmployees(22);
					break;
				case 23:
					LoadEmployees(24);
					LoadEmployees(25);
					LoadEmployees(26);
					break;
				case 27:
					LoadEmployees(28);
					LoadEmployees(29);
					LoadEmployees(32);
					LoadEmployees(35);
					break;
				case 29:
					LoadEmployees(30);
					LoadEmployees(31);
					break;
				case 32:
					LoadEmployees(33);
					LoadEmployees(34);
					break;
				case 39:
					LoadEmployees(40);
					LoadEmployees(41);
					break;
				case 43:
					LoadEmployees(44);
					LoadEmployees(45);
					LoadEmployees(47);
					LoadEmployees(48);
					break;
				case 45:
					LoadEmployees(46);
					break;
				case 49:
					LoadEmployees(50);
					LoadEmployees(51);
					break;
			}
		}
		public void LoadEmployees(int currentDepartment)
		{
			ForMainDepartments(currentDepartment);

			List<Employees> employeesList = AppConnect.BD_RussionsRoadsEntities.Employees.ToList();
			List<Departments> departmentsList = AppConnect.BD_RussionsRoadsEntities.Departments.ToList();

			for (int i = 0; i < employeesList.LongCount(); i++)
			{
				Employees employee = employeesList[i];
				string NameDepartment = "Department";
				for (int j = 0; j < departmentsList.LongCount(); j++)
				{
					Departments department = departmentsList[j];
					if (employee.DepartmentID == department.ID)
						NameDepartment = department.Name;
				}

				if (currentDepartment == employee.DepartmentID || currentDepartment == 0)
				{
					EmployeeView employeeFLV = new EmployeeView(employee.ID, employee.FIO, NameDepartment, employee.Position, employee.WorkPhone, employee.Email, employee.OfficeNumber);
					LVEmployees.Items.Add(employeeFLV);
				}
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			LoadEmployees(0);
		}

		private void Structure_Click(object sender, RoutedEventArgs e)
		{
			LVEmployees.Items.Clear();
			Button button = sender as Button;
			LoadEmployees(Convert.ToInt32(button.Name.ToString().Replace("btn","")));
		}

		private void ToEmployeeWindow(object sender, MouseButtonEventArgs e)
		{
			Border border = sender as Border;
			EmployeeView employeeFLV = border.DataContext as EmployeeView;
			foreach (var item in AppConnect.BD_RussionsRoadsEntities.Employees)
			{
				if (item.ID == employeeFLV.ID)
				{
					EmployeeWindow window = new EmployeeWindow(item);
					window.Show();
				}
			}
		}

		private void AddEmployee(object sender, MouseButtonEventArgs e)
		{
			EmployeeWindow window = new EmployeeWindow(null);
			window.Show();
		}

		private void Button_GotMouseCapture(object sender, MouseEventArgs e)
		{
			Border button = sender as Border;
			button.Opacity = 1;
		}

		private void Button_LostMouseCapture(object sender, MouseEventArgs e)
		{
			Border button = (Border)sender;
			button.Opacity = 0.6;
		}
	}
}
