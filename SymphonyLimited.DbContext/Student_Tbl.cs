//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SymphonyLimited.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student_Tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student_Tbl()
        {
            this.Course_Offering_Tbl = new HashSet<Course_Offering_Tbl>();
            this.Exam_Tbl = new HashSet<Exam_Tbl>();
            this.Result_Tbl = new HashSet<Result_Tbl>();
        }
    
        public int ID { get; set; }
        public string Student_Name { get; set; }
        public string Student_Lastname { get; set; }
        public int GPA { get; set; }
        public string Grade { get; set; }
        public string Address { get; set; }
        public long Roll_Number { get; set; }
        public string Password2 { get; set; }
        public string Email2 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Offering_Tbl> Course_Offering_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam_Tbl> Exam_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Result_Tbl> Result_Tbl { get; set; }
    }
}
