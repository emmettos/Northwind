namespace EoSoftware.Northwind.Application;

public class NewCategoryDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}

public class CategoryDto : NewCategoryDto
{
    public short Id { get; set; }
}
