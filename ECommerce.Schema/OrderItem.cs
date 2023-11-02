using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class OrderItemRequest
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }
}

public class OrderItemResponse
{

    public int OrderId { get; set; }
    public int OrderNo { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductQuantity { get; set; }
    public string TotalPrice { get; set; }


}

