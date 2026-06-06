using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace R61M9C2_Inv.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseMaster> PurchaseMasters { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public DbSet<SalesMaster> SalesMasters { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<Stock> Stocks { get; set; }

    }


    public class Stock
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int PoductId { get; set; }
        public int StockQty { get; set; }
        public double StockPrice { get; set; }
        public Product Product { get; set; }
    }

    //public class Sales
    //{
    //    public int Id { get; set; }
    //    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
    //    public DateTime SalesDate { get; set; }
    //    [ForeignKey("Product")]
    //    public int ProductId { get; set; }
    //    public int Qty { get; set; }
    //    public string CustomerName { get; set; }
    //    public Product Product { get; set; }
    //}

    //public class PurchaseDetails
    //{
    //    public int Id { get; set; }
    //    //[DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
    //    //public DateTime PurchaseDate { get; set; }
    //    [ForeignKey("Product")]
    //    public int ProductId { get; set; }
    //    public int Qty { get; set; }
        
    //    public Product Product { get; set; }
    //}



    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int CatID { get; set; }
        public double Price { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

    }

    public class Category
    {
        public Category()
        {
           // Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        [ValidateNever]
        public ICollection<Product> Products { get; set; }

    }
    public class SalesMaster
    {
        public int Id { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime SalesDate { get; set; }

        public string SaleNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }
        public double TotalPrice { get; set; }

        //public virtual Product Product { get; set; }
        [ValidateNever]
        public ICollection<SalesDetail> SalesDetails { get; set; }
    }
    public class SalesDetail
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(SalesMaster))]
        public int SaleMasterId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; }
        [ValidateNever]
        public Product Product { get; set; }
        [ValidateNever]
        public virtual SalesMaster SalesMaster { get; set; }
    }

    public class PurchaseMaster
    {
        public int Id { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public string PurchaseNumber { get; set; }
        public string VendorName { get; set; }
        public string VendorContact { get; set; }
        public double TotalAmount { get; set; }
        [ValidateNever]
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
    public class PurchaseDetail
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(PurchaseMaster))]
        public int PurchaseID { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        //public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        [ValidateNever]
        public virtual Product Product { get; set; }
        [ValidateNever]
        public virtual PurchaseMaster PurchaseMaster { get; set; }
    }


}
