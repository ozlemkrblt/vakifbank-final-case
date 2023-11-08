using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class ReceiptInfoRequest
{
    public int? RetailerId { get; set; }
    public int? ReceiptId { get; set; }
    public int AddressId { get; set; }

    public int RetailerTaxNumber;
    public int MersisNo { get; set; }

    public string CompanyName { get; set; }

}

public class ReceiptInfoResponse

{
    public int Id { get; set; }

    public string CompanyName { get; set; }
    public int? RetailerId { get; set; }
    public string RetailerUserName { get; set; }
    public string RetailerFullName { get; set; }
    public int AddressId { get; set; }
    public string Address { get; set; }

    public int RetailerTaxNumber;
    public int MersisNo { get; set; }


}