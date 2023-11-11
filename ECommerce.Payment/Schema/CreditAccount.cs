using ECommerce.Data.Domain;

namespace ECommerce.Payment.Schema.CreditAccount;
public class CreditAccountRequest
{
    public int RetailerId { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime? CloseDate { get; set; }

    public double ExpenseLimit { get; set; }

}

public class CreditAccountResponse
{

    public int RetailerId { get; set; }
    public virtual Retailer Retailer { get; set; }
    public int AccountNo { get; set; }
    public string IBAN { get; set; }
    public double Balance { get; set; }
    public string CurrencyCode { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime? CloseDate { get; set; }

    public double ExpenseLimit { get; set; }
}
