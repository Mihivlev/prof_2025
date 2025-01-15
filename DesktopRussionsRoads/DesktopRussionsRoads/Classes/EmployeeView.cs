using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopRussionsRoads.Classes
{
	internal class EmployeeView
	{
		public int ID { get; set; }
		public string FIO { get; set; }
		public string Department { get; set; }
		public string Position { get; set; }
		public string WorkPhone { get; set; }
		public string Email { get; set; }
		public string OfficeNumber { get; set; }

		public EmployeeView(int ID, string FIO, string Department, string Posiotion, string WorkPhone, string Email, string OfficeNumber)
		{
			this.ID = ID;
			this.FIO = FIO;
			this.Department = Department;
			this.Position = Posiotion;
			this.WorkPhone = WorkPhone;
			this.Email = Email;
			this.OfficeNumber = OfficeNumber;
		}
	}
}
