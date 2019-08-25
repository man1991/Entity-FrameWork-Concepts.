namespace Entity_Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    /// <summary>
    /// One class of type DbContext can expose many table
    /// A class name is Country whereas table name in underlying database is tblCountry so this is a mismatch
    /// so for mapping in code first is done by OnModelCreating event
    /// </summary>
    public class CustomerCodeFirst : DbContext
    {
        public CustomerCodeFirst()
            : base("name=CustomerCodeFirst")
        {
        }

        //to define mapping between Country class and tblCountry table
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //disables metadata check
            Database.SetInitializer<CustomerCodeFirst>(null);

            modelBuilder.Entity<Country>().ToTable("tblCountry");

            //defining a key so that it won't throw a error
            modelBuilder.Entity<Country>().HasKey(t => new { t.CountryName });
        }
        public DbSet<Country> Countries { get; set; }
    }
}
