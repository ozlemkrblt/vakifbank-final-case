namespace ECommerce.Schema;
public class ProductRequest
{

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }


}
public class ProductResponse
{

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}


