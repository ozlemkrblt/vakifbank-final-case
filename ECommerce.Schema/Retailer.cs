using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class RetailerRequest
{
    public string RetailerUserName { get; set; }

}

public class RetailerResponse
{
    public string RetailerUserName { get; set; }

    public virtual List<ReceiptInfo> ReceiptInfos { get; set; }
    public virtual List<Order> Orders { get; set; }  // one seller can order many times
}