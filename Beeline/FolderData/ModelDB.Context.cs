﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beeline.FolderData
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBEntities : DbContext
    {
        private static DBEntities context;
        public DBEntities()
            : base("name=DBEntities")
        {
        }
        public static DBEntities GetContext()
        {
            if(context == null)
            {
                context = new DBEntities();
            }
            return context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Dogovor> Dogovor { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sotr> Sotr { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StatusPhone> StatusPhone { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tarif> Tarif { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}