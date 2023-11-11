
using ECommerce.Data.Domain;
using ECommerce.Payment.Base;
using ECommerce.Payment.Domain;

public class PaymentRequest
{
    public int OrderId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentType PaymentType { get; set; }
    public double PaymentAmount { get; set; }
    public virtual Card? card { get; set; }

    public virtual EFT? eft { get; set; }
    public virtual Transfer? transfer { get; set; }
    public int? CreditAccountId { get; set; }

}

public class PaymentResponse
{

    public int OrderId { get; set; }
    public virtual Order Order { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentType PaymentType { get; set; }
    public double PaymentAmount { get; set; }
    public DateTime PaymentDate { get; set; }
    public virtual EFT? eft { get; set; }
    public virtual Transfer? transfer { get; set; }

    public virtual CreditAccount? CreditAccount { get; set; }
}
