using ECommerce.Base.Enums;
using ECommerce.Data.Domain;
using ECommerce.Payment.Base;
namespace ECommerce.Schema;
public class OrderRequest
{
    public int OrderNo { get; set; }
    public double Amount { get; set; }
    public virtual PaymentStatus PaymentStatus { get; set; }
    public int? ReceiptId { get; set; }
    public int RetailerId { get; set; }  // one order can belong to one user
    public int OrderStatus {  get; set; }

}

public class OrderResponse
{
    public int RetailerId { get; set; }

    public string RetailerUserName { get; set; }
    public int OrderNo { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
    public string PaymentStatus { get; set; }
    public virtual Receipt Receipt { get; set; }
    public virtual List<OrderItem> Items { get; set; }
    public virtual OrderStatus OrderStatus { get; set; }
}