namespace ECommerce.Schema;
public class AddressRequest
{
    public int UserId { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string PostalCode { get; set; }
}

public class AddressResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string PostalCode { get; set; }

}