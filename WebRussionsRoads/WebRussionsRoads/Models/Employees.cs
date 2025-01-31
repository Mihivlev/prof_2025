//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebRussionsRoads.Models
{
	using Newtonsoft.Json;
	using System;
    using System.Collections.Generic;

    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            this.Events = new HashSet<Events>();
        }

        public int ID { get; set; }
        public string FIO { get; set; }
        public int DepartmentID { get; set; }
        public string Position { get; set; }
        public string WorkPhone { get; set; }
        public string PersonalPhone { get; set; }
        public string OfficeNumber { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DateBirth { get; set; }
        public Nullable<int> BossID { get; set; }
        public Nullable<int> AssistantID { get; set; }

        [JsonIgnore]
        public virtual Departments Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [JsonIgnore]
        public virtual ICollection<Events> Events { get; set; }
    }
}
