using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Expense_Tracker_application.Models
{
    public class Category
    {
        public Category()
        {
            this.Users = new List<User>();
        }
        [Key]
        [ServiceStack.DataAnnotations.Unique]
        public int CategoryId { get; set; }
        [ServiceStack.DataAnnotations.Unique]
        [Required, StringLength(50), Display(Name = "Expense Category")]
        //[Index("IX_CategoryName", 1, IsUnique = true)]
        public string CategoryName { get; set; }
        //nev
        public virtual ICollection<User> Users { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        [Required, StringLength(50), Display(Name = "User Name")]
        public string UserName { get; set; }
        [ForeignKey("Category")]
        [ServiceStack.DataAnnotations.Unique]
        public int CategoryId { get; set; }

        [Required, Column(TypeName = "date"), Display(Name = "ExpenseDate,"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[FutureDate(ErrorMessage = "FutureDate entry not allowed")]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        [NotMapped]
        [ServiceStack.DataAnnotations.Unique]
        public string CategoryName { get; set; }
        //nev
        public virtual Category Category { get; set; }
    }
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
  
}
