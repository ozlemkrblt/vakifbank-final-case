using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class ReceiptRequest
{
    public int ReceiptInfoId { get; set; }
    public int OrderId { get; set; }
    //public Payment payment { get; set; }
    //public int PaymentId { get; set; }
}

public class ReceiptResponse
{
    public int OrderNo { get; set; }

    public double Amount { get; set; }
    public DateTime OrderDate { get; set; }
    //public int PaymentId { get; set; }
    public int ReceiptInfoId { get; set; }
    public ReceiptInfo ReceiptInfo { get; set; }

}