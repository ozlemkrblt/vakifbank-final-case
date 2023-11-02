using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class RetailerRequest
{
    public string RetailerName { get; set; }

    public string ReceiptInfo { get; set; }
}

public class RetailerResponse
{
    public string RetailerName { get; set; }

    public string ReceiptInfo { get; set; }
    public virtual List<Order> Orders { get; set; }  // one seller can order many times
}