using ECommerce.Base.Enums;
using ECommerce.Data.Domain;
using System.Collections;
using System.Collections.Generic;

namespace ECommerce.Schema;
public class StockRequest
{
    public int Id { get; set; }
    public int MaxStock { get; set; }
    public int StockStatus { get; set; }

    public int ProductId { get; set; }

    public int StockValue { get; set; }

    public Dictionary<int, int> ProductsToUpdateStock = new Dictionary<int, int>();


}
public class StockResponse
{
    public int Id { get; set; }

    public int MaxStock { get; set; }
    public int StockValue { get; set; }

    public virtual StockStatus StockStatus { get; set; }
    public string ProductName { get; set; }

}
