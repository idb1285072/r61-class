using Evidence_M9_MD_AJAX_Component.Models;

namespace Evidence_M9_MD_AJAX_Component.ViewModels
{
    public class OrderInfoVm
    {
        //public  Order Order { get; set; }
        public int Id { get; set; }

        public string OrderNumber { get; set; } = null!;

        public string? CustomerName { get; set; }

        public DateOnly? OrderDate { get; set; }

        public string? Picture { get; set; }

        public bool? IsDelivered { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
       
    }
}
