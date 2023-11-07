﻿using ECommerce.Data.Domain;

namespace ECommerce.Schema;
public class ProductRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public int StockId { get; set; }

}
public class ProductResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int StockId { get; set; }
    public virtual  Stock Stock { get; set; }
}


