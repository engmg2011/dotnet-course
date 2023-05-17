namespace ProjectModels;

public class Product
{
    public int id { get; set; }
    public string title { get; set; }
    public double price { get; set; }

    public bool isActive { get; set; }

    public List<ProductProperties> ProductSummary = new();
}

public class ProductProperties
{
    public int? Id;
    public string? Key;
    public string? Value;
}
