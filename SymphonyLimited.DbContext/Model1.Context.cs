﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Symphony_LimitedEntities : DbContext
    {
        public Symphony_LimitedEntities()
            : base("name=Symphony_LimitedEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<About_Tbl> About_Tbl { get; set; }
        public virtual DbSet<Admin_Tbl> Admin_Tbl { get; set; }
        public virtual DbSet<ContactForm_Tbl> ContactForm_Tbl { get; set; }
        public virtual DbSet<ContactPage_Tbl> ContactPage_Tbl { get; set; }
        public virtual DbSet<Course_Offering_Tbl> Course_Offering_Tbl { get; set; }
        public virtual DbSet<Course_Tbl> Course_Tbl { get; set; }
        public virtual DbSet<Exam_Tbl> Exam_Tbl { get; set; }
        public virtual DbSet<Faculty_Tbl> Faculty_Tbl { get; set; }
        public virtual DbSet<FAQ_Tbl> FAQ_Tbl { get; set; }
        public virtual DbSet<Figure_Tbl> Figure_Tbl { get; set; }
        public virtual DbSet<Gallery_Tbl> Gallery_Tbl { get; set; }
        public virtual DbSet<History_Tbl> History_Tbl { get; set; }
        public virtual DbSet<Lab_Tbl> Lab_Tbl { get; set; }
        public virtual DbSet<OtherBranches_Tbl> OtherBranches_Tbl { get; set; }
        public virtual DbSet<OurTeam_Tbl> OurTeam_Tbl { get; set; }
        public virtual DbSet<Result_Tbl> Result_Tbl { get; set; }
        public virtual DbSet<Semester_Tbl_> Semester_Tbl_ { get; set; }
        public virtual DbSet<Student_Tbl> Student_Tbl { get; set; }
        public virtual DbSet<WhatPeopleSay_Tbl> WhatPeopleSay_Tbl { get; set; }
    }
}
