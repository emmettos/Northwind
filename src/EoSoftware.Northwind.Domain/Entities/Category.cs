namespace EoSoftware.Northwind.Domain;

public class Category
{
    public Category()
    {
        Products = new HashSet<Product>();
    }

    public short CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; }
}
