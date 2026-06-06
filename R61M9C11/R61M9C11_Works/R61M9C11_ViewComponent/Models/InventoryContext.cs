using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace R61M9C11_ViewComponent.Models
{
    public class InventoryContext:DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {
            
        }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class Product
    {
        public int ProductID {get;set;}

   public string  ProductName {get;set;}

        public string GenericName { get; set; }
        public int CategoryID  {get;set;}

        public int ManufacturerID  {get;set;}

public string BatchNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpiryDate  {get; set;}
        public int QuantityInStock  {get; set;}
        public int ReorderLevel {get; set;}
        public double UnitPrice {get; set;}
        public string ShelfLocation {get; set;}
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
