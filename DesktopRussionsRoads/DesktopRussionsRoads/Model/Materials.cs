//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopRussionsRoads.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Materials
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.DateTime> DateEdit { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int DepartmentID { get; set; }
        public int AuthorID { get; set; }
    
        public virtual Departments Departments { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
