namespace ECommerce.Schema;
public class ReceiptRequest
{
    public int ReceiptInfoId { get; set; }
    public int RetailerId { get; set; }

    //public Payment payment { get; set; }
    public int PaymentId { get; set; }

}

public class ReceiptResponse {
    public int RetailerId { get; set; }

    public int RetailerName { get; set; }
    public int PaymentId { get; set; }

    public int ReceiptInfoId { get; set; }
    public string ReceiptInformation {  get; set; }

}