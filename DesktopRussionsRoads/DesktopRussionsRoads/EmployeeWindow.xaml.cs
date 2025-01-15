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
using System.Windows.Shapes;

namespace DesktopRussionsRoads
{
	/// <summary>
	/// Логика взаимодействия для EmployeeWindow.xaml
	/// </summary>
	public partial class EmployeeWindow : Window
	{
		private Employees currentEmployee = new Employees();
		public EmployeeWindow(Employees selected)
		{
			InitializeComponent();

			if (selected != null) currentEmployee = selected;
			else
			{
				WEmployee.Title = "Добавление нового сотрудника";
				btnSave.Text = "Создать";
				btnDelete.Text = "Отменить";
			}
			DataContext = currentEmployee;

			int[] MainDepartments = { 1, 7, 12, 18, 20, 23, 27, 29, 32, 39, 43, 45, 49 };
			List<Departments> departmentsList = AppConnect.BD_RussionsRoadsEntities.Departments.ToList();
			for (int i = departmentsList.Count - 1; i >= 0; i--)
			{
				Departments dep = departmentsList[i];
				if (MainDepartments.Contains(dep.ID)) departmentsList.Remove(dep);
			}

			for (int i = 0; i < departmentsList.Count; i++)
			{
				Departments department = departmentsList[i];

				if (MainDepartments.Contains(department.ID)) continue;
				string textBlock = department.Name;
				CBDepartment.Items.Add(textBlock);
				if (department.ID == currentEmployee.DepartmentID) CBDepartment.SelectedIndex = i;
			}
		}

		private void SaveChanges(object sender, MouseButtonEventArgs e)
		{
			int[] MainDepartments = { 1, 7, 12, 18, 20, 23, 27, 29, 32, 39, 43, 45, 49 };
			StringBuilder error = new StringBuilder();
			if (string.IsNullOrEmpty(IFIO.Text)) error.AppendLine("Введите ФИО");
			if (string.IsNullOrEmpty(CBDepartment.Text)) error.AppendLine("Выберите отдел");
			if (string.IsNullOrEmpty(IPosition.Text)) error.AppendLine("Введите должность");
			if (string.IsNullOrEmpty(IWorkPhone.Text)) error.AppendLine("Введите номер рабочего телефона");
			else if (IWorkPhone.Text.Length > 10) error.AppendLine("строка с номером слишком длинная, сократите ее");
			if (string.IsNullOrEmpty(IOfficeNumber.Text)) error.AppendLine("Введите номер кабинета");
			if (string.IsNullOrEmpty(IEmail.Text)) error.AppendLine("Введите Email");
			if (string.IsNullOrEmpty(IDateBirth.Text)) error.AppendLine("Введите дату рождения");

			if (error.Length > 0)
				MessageBox.Show(error.ToString());
			else
			{
				AppConnect.BD_RussionsRoadsEntities.Departments.ToList().ForEach(dep =>
				{
					if (dep.Name == CBDepartment.SelectedValue.ToString() && !MainDepartments.Contains(dep.ID))
						currentEmployee.DepartmentID = dep.ID;
				});


				if (currentEmployee.ID == 0) AppConnect.BD_RussionsRoadsEntities.Employees.Add(currentEmployee);
				AppConnect.BD_RussionsRoadsEntities.SaveChanges();
				MessageBox.Show("Информация сохранена");
			}
		}

		private void Delete(object sender, MouseButtonEventArgs e)
		{
			if (currentEmployee.ID == 0) WEmployee.Close();
			else
			{
				MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить данные о сотруднике", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (result == MessageBoxResult.Yes)
				{
					AppConnect.BD_RussionsRoadsEntities.Employees.Remove(currentEmployee);
					AppConnect.BD_RussionsRoadsEntities.SaveChanges();
					WEmployee.Close();
				}
			}
		}
	}
}

