﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class test4DBEntities2 : DbContext
    {
        public test4DBEntities2()
            : base("name=test4DBEntities2")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public void a()
        {
          
        }    
        
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public System.Data.Entity.DbSet<test4.Models.UserClubModel> UserClubModels { get; set; }
    }
}
