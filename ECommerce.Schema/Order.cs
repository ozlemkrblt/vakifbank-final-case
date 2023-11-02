using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class OrderRequest
{
    public int OrderNo { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
    public double PaymentStatus { get; set; }


    public int UserId { get; set; }  // one order can belong to one user

    
}

public class OrderResponse
{

    public int UserId { get; set; }

    public string UserName { get; set; }
    public int OrderNo { get; set; }
    public DateTime OrderDate { get; set; }
    public double Amount { get; set; }
    public double PaymentStatus { get; set; }

    public virtual List<OrderItem> Items { get; set; };
}